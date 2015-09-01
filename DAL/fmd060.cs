/**  版本信息模板在安装目录下，可自行修改。
* fmd060.cs
*
* 功 能： N/A
* 类 名： fmd060
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
	/// 数据访问类:fmd060
	/// </summary>
	public partial class fmd060
	{
		public fmd060()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PM,string PH,string CLBH)
		{

            string SearchPMPH_CLBH = string.Empty;
            string[] strArrCLBH = CLBH.Split('-');
            if (strArrCLBH.Length == 2)
            {
                SearchPMPH_CLBH = strArrCLBH[0];
            }
            else
            {
                SearchPMPH_CLBH = CLBH;
            }
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fmd060");
            strSql.Append(" where PM='" + PM + "' and PH='" + PH + "' and CLBH='" + SearchPMPH_CLBH + "' ");
			return DbHelperMySql.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string AddSql(Model.fmd060 model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.PM != null)
			{
				strSql1.Append("PM,");
				strSql2.Append("'"+model.PM+"',");
			}
			if (model.PH != null)
			{
				strSql1.Append("PH,");
				strSql2.Append("'"+model.PH+"',");
			}
			if (model.CLBH != null)
			{
				strSql1.Append("CLBH,");
				strSql2.Append("'"+model.CLBH+"',");
			}
			if (model.JLDW != null)
			{
				strSql1.Append("JLDW,");
				strSql2.Append("'"+model.JLDW+"',");
			}
			if (model.FLH != null)
			{
				strSql1.Append("FLH,");
				strSql2.Append("'"+model.FLH+"',");
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
			if (model.CPMS != null)
			{
				strSql1.Append("CPMS,");
				strSql2.Append("'"+model.CPMS+"',");
			}
			if (model.XDSLBZ != null)
			{
				strSql1.Append("XDSLBZ,");
				strSql2.Append(""+model.XDSLBZ+",");
			}
			if (model.DDSLBZ != null)
			{
				strSql1.Append("DDSLBZ,");
				strSql2.Append(""+model.DDSLBZ+",");
			}
			if (model.XQF != null)
			{
				strSql1.Append("XQF,");
				strSql2.Append("'"+model.XQF+"',");
			}
			if (model.XSLBZ != null)
			{
				strSql1.Append("XSLBZ,");
				strSql2.Append(""+model.XSLBZ+",");
			}
			if (model.ZXBZ != null)
			{
				strSql1.Append("ZXBZ,");
				strSql2.Append("'"+model.ZXBZ+"',");
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


            if (model.ECLH != null)
			{
                strSql1.Append("RCLH,");
				strSql2.Append("'"+model.ECLH+"',");
			}

            

			strSql.Append("insert into fmd060(");
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
		public string UpdateSql(Model.fmd060 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fmd060 set ");
			if (model.JLDW != null)
			{
				strSql.Append("JLDW='"+model.JLDW+"',");
			}
			else
			{
				strSql.Append("JLDW= null ,");
			}
			if (model.FLH != null)
			{
				strSql.Append("FLH='"+model.FLH+"',");
			}
			else
			{
				strSql.Append("FLH= null ,");
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
			if (model.CPMS != null)
			{
				strSql.Append("CPMS='"+model.CPMS+"',");
			}
			else
			{
				strSql.Append("CPMS= null ,");
			}
			if (model.XDSLBZ != null)
			{
				strSql.Append("XDSLBZ="+model.XDSLBZ+",");
			}
			else
			{
				strSql.Append("XDSLBZ= null ,");
			}
			if (model.DDSLBZ != null)
			{
				strSql.Append("DDSLBZ="+model.DDSLBZ+",");
			}
			else
			{
				strSql.Append("DDSLBZ= null ,");
			}
			if (model.XQF != null)
			{
				strSql.Append("XQF='"+model.XQF+"',");
			}
			else
			{
				strSql.Append("XQF= null ,");
			}
			if (model.XSLBZ != null)
			{
				strSql.Append("XSLBZ="+model.XSLBZ+",");
			}
			else
			{
				strSql.Append("XSLBZ= null ,");
			}
			if (model.ZXBZ != null)
			{
				strSql.Append("ZXBZ='"+model.ZXBZ+"',");
			}
			else
			{
				strSql.Append("ZXBZ= null ,");
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


            if (model.ECLH != null)
            {
                strSql.Append("RCLH='" + model.ECLH + "',");
            }
            else
            {
                strSql.Append("RCLH= null ,");
            }

			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where PM='"+ model.PM+"' and PH='"+ model.PH+"' and CLBH='"+ model.CLBH+"' ");
			// int rowsAffected=DbHelperMySql.ExecuteSql(strSql.ToString());

            return strSql.ToString();
			
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public string Delete(string PM,string PH,string CLBH)
		{
            string SearchPMPH_CLBH = string.Empty;
            string[] strArrCLBH = CLBH.Split('-');
            if (strArrCLBH.Length == 2)
            {
                SearchPMPH_CLBH = strArrCLBH[0];
            }
            else
            {
                SearchPMPH_CLBH = CLBH;
            }
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fmd060 ");
            strSql.Append(" where PM='" + PM + "' and PH='" + PH + "' and CLBH='" + SearchPMPH_CLBH + "' ");
			// int rowsAffected=DbHelperMySql.ExecuteSql(strSql.ToString());
            return strSql.ToString();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd060 GetModel(string PM,string PH,string CLBH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" PM,PH,CLBH,JLDW,FLH,ZXKC,ZDKC,CPMS,XDSLBZ,DDSLBZ,XQF,XSLBZ,ZXBZ,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" from fmd060 ");
			strSql.Append(" where PM='"+PM+"' and PH='"+PH+"' and CLBH='"+CLBH+"' " );
			Model.fmd060 model=new Model.fmd060();
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
		public Model.fmd060 DataRowToModel(DataRow row)
		{
			Model.fmd060 model=new Model.fmd060();
			if (row != null)
			{
				if(row["PM"]!=null)
				{
					model.PM=row["PM"].ToString();
				}
				if(row["PH"]!=null)
				{
					model.PH=row["PH"].ToString();
				}
				if(row["CLBH"]!=null)
				{
					model.CLBH=row["CLBH"].ToString();
				}
				if(row["JLDW"]!=null)
				{
					model.JLDW=row["JLDW"].ToString();
				}
				if(row["FLH"]!=null)
				{
					model.FLH=row["FLH"].ToString();
				}
				if(row["ZXKC"]!=null && row["ZXKC"].ToString()!="")
				{
					model.ZXKC=decimal.Parse(row["ZXKC"].ToString());
				}
				if(row["ZDKC"]!=null && row["ZDKC"].ToString()!="")
				{
					model.ZDKC=decimal.Parse(row["ZDKC"].ToString());
				}
				if(row["CPMS"]!=null)
				{
					model.CPMS=row["CPMS"].ToString();
				}
				if(row["XDSLBZ"]!=null && row["XDSLBZ"].ToString()!="")
				{
					model.XDSLBZ=int.Parse(row["XDSLBZ"].ToString());
				}
				if(row["DDSLBZ"]!=null && row["DDSLBZ"].ToString()!="")
				{
					model.DDSLBZ=int.Parse(row["DDSLBZ"].ToString());
				}
				if(row["XQF"]!=null)
				{
					model.XQF=row["XQF"].ToString();
				}
				if(row["XSLBZ"]!=null && row["XSLBZ"].ToString()!="")
				{
					model.XSLBZ=int.Parse(row["XSLBZ"].ToString());
				}
				if(row["ZXBZ"]!=null)
				{
					model.ZXBZ=row["ZXBZ"].ToString();
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
			strSql.Append("select PM,PH,CLBH,JLDW,FLH,ZXKC,ZDKC,CPMS,XDSLBZ,DDSLBZ,XQF,XSLBZ,ZXBZ,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" FROM fmd060 ");
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
			strSql.Append("select count(1) FROM fmd060 ");
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
			strSql.Append(")AS Row, T.*  from fmd060 T ");
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
        /// 是否存在该记录
        /// </summary>
        public bool ExistsEVE(string PM, string PH, string CLBH)
        {

            string SearchPMPH_CLBH = string.Empty;
            string[] strArrCLBH = CLBH.Split('-');
            if (strArrCLBH.Length == 2)
            {
                SearchPMPH_CLBH = strArrCLBH[0];
            }
            else
            {
                SearchPMPH_CLBH = CLBH;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from fmd060");
            strSql.Append(" where CLBH='" + SearchPMPH_CLBH + "' ");
            if(!string.IsNullOrEmpty(PM))
            {
                strSql.Append(" AND PM='" + PM + "' ");
            }
            if (!string.IsNullOrEmpty(PH))
            {
                 strSql.Append(" and PH='" + PH + "'  ");
            }
            //return strSql.ToString();
            return DbHelperMySql.Exists(strSql.ToString());
        }


        /// <summary>
        /// 获取入库标准（小袋，大袋，箱标准）
        /// </summary>
        public DataTable getRKBiaoZhun(string PM, string PH, string CLBH)
        {

            string SearchPMPH_CLBH = string.Empty;
            string[] strArrCLBH = CLBH.Split('-');
            if (strArrCLBH.Length == 2)
            {
                SearchPMPH_CLBH = strArrCLBH[0];
            }
            else
            {
                SearchPMPH_CLBH = CLBH;
            }
            StringBuilder strSql = new StringBuilder();
            //strSql.Append(" select XDSLBZ,round(DDSLBZ/XDSLBZ,0) DDSLBZ,round(XSLBZ/DDSLBZ/XDSLBZ,0) XSLBZ,XQF from fmd060");

            strSql.Append(" select  XQF,");
            strSql.Append(" XDSLBZ,round(DDSLBZ/XDSLBZ,0) DDSLBZ, ");
            strSql.Append(" if(XQF='002', ");
            strSql.Append(" round(XSLBZ/DDSLBZ,0), ");
            strSql.Append(" round(XSLBZ/XDSLBZ,0)) XSLBZ ");
            strSql.Append(" from fmd060 ");

            strSql.Append(" where PM='" + PM + "' and PH='" + PH + "' and CLBH='" + SearchPMPH_CLBH + "' ");
            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }
         

        public DataTable GetDaTaForPC08Spread(string PM, string PH, string CLBH, string FLH,string ECLH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT                                                                               ");
            strSql.Append("a.PM,                                                                                ");
            strSql.Append("a.PH,                                                                                ");
            strSql.Append("a.CLBH,                                                                              ");
            strSql.Append("a.JLDW JLDW_BH,                                                                      ");
            strSql.Append("b.ZSMC JLDW,                                                                         ");
            strSql.Append("c.ZSMC FLH,                                                                               ");
            strSql.Append("a.ZXKC,                                                                              ");
            strSql.Append("a.ZDKC,                                                                              ");
            strSql.Append("a.CPMS,                                                                              ");
            strSql.Append("a.XDSLBZ,                                                                            ");
            strSql.Append("a.DDSLBZ,                                                                            ");
            strSql.Append("d.ZSMC XQF,                                                                               ");
            strSql.Append("a.XSLBZ,                                                                             ");
            strSql.Append("a.ZXBZ   , case IFNULL(a.RCLH,'0') when '1' then '是' when '0' then '否' end as ECLH                                                                            ");
            strSql.Append("FROM                                                                                 ");
            strSql.Append("fmd060 a                                                                             ");
            strSql.Append("LEFT JOIN (SELECT ZSMC,MCKEY FROM fmd000 WHERE glbh='06')                            ");
            strSql.Append("b ON (a.JLDW=b.MCKEY)                                                                ");
            strSql.Append("LEFT JOIN (SELECT ZSMC,MCKEY FROM fmd000 WHERE glbh='05')   c on (a.FLH=c.MCKEY)                         ");
            strSql.Append("LEFT JOIN (SELECT ZSMC,MCKEY FROM fmd000 WHERE glbh='10')   d on (a.XQF=d.MCKEY)                         ");

            strSql.Append(" where 1=1 ");
            if (string.IsNullOrEmpty(PM) == false)
            {
                strSql.Append(" and PM like '%"+PM+"%'");
            }
            if (string.IsNullOrEmpty(PH) == false)
            {
                strSql.Append(" and PH like '%" + PH + "%'");
            }
            if (string.IsNullOrEmpty(CLBH) == false)
            {
                strSql.Append(" and CLBH like '%" + CLBH + "%'");
            }
            if (string.IsNullOrEmpty(FLH) == false)
            {
                strSql.Append(" and FLH like '%" + FLH + "%'");
            }
            if (string.IsNullOrEmpty(ECLH) == false)
            {
                strSql.Append("and IFNULL(a.RCLH,'0')='"+ECLH+"'  ");
            }

            strSql.Append(" order by a.PM,a.PH,a.CLBH ");
             return DbHelperMySql.Query(strSql.ToString()).Tables[0];
         }
        /// <summary>
        /// 是否存在该记录(品名)
        /// </summary>
        public bool ExistsPM(string PM)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from fmd060");
            strSql.Append(" where PM='" + PM + "'  ");
            return DbHelperMySql.Exists(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录(品号)
        /// </summary>
        public bool ExistsPH(string PM, string PH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from fmd060");
            strSql.Append(" where PM='" + PM + "' and PH='" + PH + "'  ");
            return DbHelperMySql.Exists(strSql.ToString());
        }


        public DataTable get_DT(string PM, string PH, string CLBH, string QF)
        {
            string SearchPMPH_CLBH = string.Empty;
            string[] strArrCLBH = CLBH.Split('-');
            if (strArrCLBH.Length == 2)
            {
                SearchPMPH_CLBH = strArrCLBH[0];
            }
            else
            {
                SearchPMPH_CLBH = CLBH;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select distinct " + QF + " as KHMC ," + QF + " as  KHBH from FMD060");
            strSql.Append(" where 1=1 and ");
            if (string.IsNullOrEmpty(PM) == false)
            {
                strSql.Append(" PM='"+PM+"' and");
            }
            if (string.IsNullOrEmpty(PH) == false)
            {
                strSql.Append(" PH='" + PH + "' and");
            }
            if (string.IsNullOrEmpty(CLBH) == false)
            {
                strSql.Append(" CLBH='" + CLBH + "' and");
            }
            strSql.Append("  1=1 ");
            return DbHelperMySql.Query(strSql.ToString()).Tables[0];

          }
       


        /// <summary>
        /// 是否存在该记录(材料编号)
        /// </summary>
        public bool ExistsCLBH(string PM, string PH, string CLBH)
        {
            string SearchPMPH_CLBH = string.Empty;
            string[] strArrCLBH = CLBH.Split('-');
            if (strArrCLBH.Length == 2)
            {
                SearchPMPH_CLBH = strArrCLBH[0];
            }
            else
            {
                SearchPMPH_CLBH = CLBH;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from fmd060");
            strSql.Append(" where PM='" + PM + "' and PH='" + PH + "' and CLBH='" + SearchPMPH_CLBH + "'  ");
            return DbHelperMySql.Exists(strSql.ToString());
        }

        /// <summary>
        /// 根据材料编号获取品名 或者 品号的列表
        /// </summary>
        /// <param name="CLBH">材料编号</param>
        /// <param name="QF">区分</param>
        /// <returns></returns>
        public DataTable getPM_PHByCLBH(string CLBH,string QF)
        {
            string SearchPMPH_CLBH = string.Empty;
            string[] strArrCLBH = CLBH.Split('-');
            if (strArrCLBH.Length == 2)
            {
                SearchPMPH_CLBH = strArrCLBH[0];
            }
            else
            {
                SearchPMPH_CLBH = CLBH;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select distinct " + QF + " as ZSMC ," + QF + " as  MCKEY from FMD060");
            strSql.Append(" where CLBH='" + SearchPMPH_CLBH + "';  ");
            return DbHelperMySql.Query(strSql.ToString()).Tables[0];

        }

        /// <summary>
        /// 根据品名，品号，材料编号 获取此种产品是否需要二次硫化
        /// </summary>
        /// <param name="PM">品名</param>
        /// <param name="PH">品号</param>
        /// <param name="CLBH">材料编号</param>
        /// <returns></returns>
        public bool getERCLHByCLBH_PM_PH(string PM,string PH,string CLBH)
        {

            string SearchPMPH_CLBH = string.Empty;
            string[] strArrCLBH = CLBH.Split('-');
            if (strArrCLBH.Length == 2)
            {
                SearchPMPH_CLBH = strArrCLBH[0];
            }
            else
            {
                SearchPMPH_CLBH = CLBH;
            }
            bool bResult = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RCLH as  ERCLH from FMD060");
            strSql.Append(" where CLBH='" + SearchPMPH_CLBH + "' and PM='" + PM + "' and PH='" + PH + "'  ");
            DataTable retDB = DbHelperMySql.Query(strSql.ToString()).Tables[0];
            if (retDB.Rows.Count > 0)
            {
                bResult = "1".Equals(retDB.Rows[0]["ERCLH"]) ? true : false;
            }
            return bResult;
        }
		#endregion  MethodEx
	}
}

