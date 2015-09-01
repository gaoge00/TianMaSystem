/**  版本信息模板在安装目录下，可自行修改。
* fmd040.cs
*
* 功 能： N/A
* 类 名： fmd040
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
	/// 数据访问类:fmd040
	/// </summary>
	public partial class fmd040
	{
		public fmd040()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string YCLBHBS)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fmd040");
			strSql.Append(" where YCLBHBS='"+YCLBHBS+"' ");
			return DbHelperMySql.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public string AddSQL(Model.fmd040 model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.YCLBHBS != null)
			{
				strSql1.Append("YCLBHBS,");
				strSql2.Append("'"+model.YCLBHBS+"',");
			}
			if (model.YCLBHGHS != null)
			{
				strSql1.Append("YCLBHGHS,");
				strSql2.Append("'"+model.YCLBHGHS+"',");
			}
			if (model.YCLLX != null)
			{
				strSql1.Append("YCLLX,");
				strSql2.Append("'"+model.YCLLX+"',");
			}
			if (model.ZT != null)
			{
				strSql1.Append("ZT,");
				strSql2.Append("'"+model.ZT+"',");
			}
			if (model.YXTS != null)
			{
				strSql1.Append("YXTS,");
				strSql2.Append(""+model.YXTS+",");
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
			if (model.JLDW != null)
			{
				strSql1.Append("JLDW,");
				strSql2.Append("'"+model.JLDW+"',");
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
			strSql.Append("insert into fmd040(");
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
        public string UpdateSQL(Model.fmd040 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fmd040 set ");
			if (model.YCLBHGHS != null)
			{
				strSql.Append("YCLBHGHS='"+model.YCLBHGHS+"',");
			}
			else
			{
				strSql.Append("YCLBHGHS= null ,");
			}
			if (model.YCLLX != null)
			{
				strSql.Append("YCLLX='"+model.YCLLX+"',");
			}
			else
			{
				strSql.Append("YCLLX= null ,");
			}
			if (model.ZT != null)
			{
				strSql.Append("ZT='"+model.ZT+"',");
			}
			else
			{
				strSql.Append("ZT= null ,");
			}
			if (model.YXTS != null)
			{
				strSql.Append("YXTS="+model.YXTS+",");
			}
			else
			{
				strSql.Append("YXTS= null ,");
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
			if (model.JLDW != null)
			{
				strSql.Append("JLDW='"+model.JLDW+"',");
			}
			else
			{
				strSql.Append("JLDW= null ,");
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
			strSql.Append(" where YCLBHBS='"+ model.YCLBHBS+"' ");

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
		public string Delete(string YCLBHBS)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update  fmd040 set ZT='1' ");
			strSql.Append(" where YCLBHBS='"+YCLBHBS+"' " );
			int rowsAffected=DbHelperMySql.ExecuteSql(strSql.ToString());
            return strSql.ToString();
            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
		}
        public string Del(string YCLBHBS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from   fmd040  ");
            strSql.Append(" where YCLBHBS='" + YCLBHBS + "' ");
            int rowsAffected = DbHelperMySql.ExecuteSql(strSql.ToString());
            return strSql.ToString();
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string YCLBHBSlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fmd040 ");
			strSql.Append(" where YCLBHBS in ("+YCLBHBSlist + ")  ");
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
		public Model.fmd040 GetModel(string YCLBHBS)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" YCLBHBS,YCLBHGHS,YCLLX,ZT,YXTS,JJ,MS,ZXKC,ZDKC,JLDW,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" from fmd040 ");
			strSql.Append(" where YCLBHBS='"+YCLBHBS+"' " );
			Model.fmd040 model=new Model.fmd040();
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
		public Model.fmd040 DataRowToModel(DataRow row)
		{
			Model.fmd040 model=new Model.fmd040();
			if (row != null)
			{
				if(row["YCLBHBS"]!=null)
				{
					model.YCLBHBS=row["YCLBHBS"].ToString();
				}
				if(row["YCLBHGHS"]!=null)
				{
					model.YCLBHGHS=row["YCLBHGHS"].ToString();
				}
				if(row["YCLLX"]!=null)
				{
					model.YCLLX=row["YCLLX"].ToString();
				}
				if(row["ZT"]!=null)
				{
					model.ZT=row["ZT"].ToString();
				}
				if(row["YXTS"]!=null && row["YXTS"].ToString()!="")
				{
					model.YXTS=int.Parse(row["YXTS"].ToString());
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
				if(row["JLDW"]!=null)
				{
					model.JLDW=row["JLDW"].ToString();
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
			strSql.Append("select YCLBHBS,YCLBHGHS,YCLLX,ZT,YXTS,JJ,MS,ZXKC,ZDKC,JLDW,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" FROM fmd040 ");
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
			strSql.Append("select count(1) FROM fmd040 ");
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
				strSql.Append("order by T.YCLBHBS desc");
			}
			strSql.Append(")AS Row, T.*  from fmd040 T ");
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
        public DataTable GetYCLBH()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select DISTINCT YCLBHBS ");
            strSql.Append(" FROM fmd040 ");
            strSql.Append(" where ZT = '0' order by YCLLX asc,YCLBHBS asc");
            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 得到原材料入库明细
        /// </summary>
        /// <param name="YCLBH"></param>
        /// <param name="rkrq"></param>
        /// <param name="zf"></param>
        /// <returns></returns>
        public DataTable GetYCLRK(string YCLBH,string rkrq ,string zf)
        {
            string strSql = "Call UP_GetYCLRK('" + YCLBH + "','" + rkrq + "','" + zf + "');";
            DataTable myDt=DbHelperMySql.Query(strSql).Tables[0];
            return myDt;
        }

        /// <summary>
        /// 得到原材料明细
        /// </summary>
        /// <param name="YCLBH"></param>
        /// <returns></returns>
        public DataTable GetYCLBH_MX(string YCLBH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  ");
            strSql.Append(" date_add(func_get_split_string('" + YCLBH + "','_',4),INTERVAL YXTS DAY) as 使用期限 , ");
            strSql.Append(" func_get_split_string('" + YCLBH + "','_',3) as 原材料编号, ");
            strSql.Append(" '辅料' as 原材料类型, ");
            strSql.Append(" '" + YCLBH + "' as 入桶单号 ");
            strSql.Append(" from FMD040 where YCLBHBS=func_get_split_string('" + YCLBH + "','_',3); ");

            DataTable myDt = DbHelperMySql.Query(strSql.ToString()).Tables[0];
            return myDt;
        }


        /// <summary>
        /// 得到原材料明细
        /// </summary>
        /// <param name="YCLBH"></param>
        /// <returns></returns>
        public DataTable GetDaTaForPC08Spread(string YCLLX,string YCLBH,string ZT,string strQF)
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





            strSql.Append("select YCLBHBS,                                                                       ");
            strSql.Append("YCLBHGHS,                                                                             ");
            strSql.Append("b.ZSMC YCLLX,                                                                         ");
            strSql.Append("CASE ZT WHEN '0' THEN '正常' else '已作废' END ZT,                                         ");
            strSql.Append("YXTS,                                                                                 ");
            strSql.Append("JJ,                                                                                   ");
            strSql.Append("MS,                                                                                   ");
            strSql.Append("ZXKC,                                                                                 ");
            strSql.Append("ZDKC,                                                                                 ");
            strSql.Append("JLDW                                                                                  ");
            strSql.Append("from fmd040 a                                                                         ");
            strSql.Append("left join (select MCKEY,ZSMC from fmd000 where GLBH='03'  ) b  on (a.YCLLX=b.MCKEY)   ");




            strSql.Append("  where  1=1                                                                   ");
            if (string.IsNullOrEmpty(YCLLX) == false)
            {
                strSql.Append("and YCLLX ='"+YCLLX+"' ");
            }
            if (string.IsNullOrEmpty(YCLBH) == false)
            {
                if (strQF.Equals("="))
                {
                    strSql.Append("and YCLBHBS ='" + YCLBH + "' ");
                }
                else
                {
                    strSql.Append("and YCLBHBS like '%" + YCLBH + "%' ");//like '%" + YCLBH + "%'
                }
                //='" + YCLBH + "'
            }
            if (string.IsNullOrEmpty(ZT) == false)
            {
                strSql.Append("and ZT ='" + ZT + "' ");
            }

            strSql.Append(" order by ZT desc,YCLLX,YCLBHBS ");

            DataTable myDt = DbHelperMySql.Query(strSql.ToString()).Tables[0];
            return myDt;
        }

        /// <summary>
        /// 得到公差
        /// </summary>
        /// <param name="zl"></param>
        /// <returns></returns>
        public decimal GET_GC(decimal zl)
        {
            string strSql = "select UF_GET_GC('" + zl + "');";
            return  Convert.ToDecimal(DbHelperMySql.GetSingle(strSql));
        }

        public string Get_YCLLX(string YCLBH)
        {
            string strSql = "select YCLBHBS,YCLLX,b.ZSMC  ZSMC from fmd040 a LEFT JOIN fmd000 b ON (a.YCLLX=b.MCKEY and b.GLBH='03') WHERE a.YCLBHBS='" + YCLBH + "'";
            DataTable myDt = DbHelperMySql.Query(strSql.ToString()).Tables[0];

            if (myDt.Rows.Count > 0)
            {
                return myDt.Rows[0]["ZSMC"].ToString();
            }
            else
            {
                return "";
            }
   
        }

		#endregion  MethodEx
	}
}

