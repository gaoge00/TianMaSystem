/**  版本信息模板在安装目录下，可自行修改。
* fmd070.cs
*
* 功 能： N/A
* 类 名： fmd070
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:53   N/A    初版
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
using System.Collections;
//using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:fmd070
	/// </summary>
	public partial class fmd070
	{
		public fmd070()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CLBH,string PHBBH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fmd070");
			strSql.Append(" where CLBH='"+CLBH+"' and PHBBH='"+PHBBH+"' ");
			return DbHelperMySql.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.fmd070 model)
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

        public string Add_SQL(Model.fmd070 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.CLBH != null)
            {
                strSql1.Append("CLBH,");
                strSql2.Append("'" + model.CLBH + "',");
            }
            if (model.PHBBH != null)
            {
                strSql1.Append("PHBBH,");
                strSql2.Append("'" + model.PHBBH + "',");
            }
            if (model.ZDRQ != null)
            {
                strSql1.Append("ZDRQ,");
                strSql2.Append("'" + model.ZDRQ + "',");
            }
            if (model.ZT != null)
            {
                strSql1.Append("ZT,");
                strSql2.Append("'" + model.ZT + "',");
            }
            if (model.BL != null)
            {
                strSql1.Append("BL,");
                strSql2.Append("'" + model.BL + "',");
            }
            if (model.SYBH != null)
            {
                strSql1.Append("SYBH,");
                strSql2.Append("'" + model.SYBH + "',");
            }
            if (model.PZRBH != null)
            {
                strSql1.Append("PZRBH,");
                strSql2.Append("'" + model.PZRBH + "',");
            }
            if (model.BZ != null)
            {
                strSql1.Append("BZ,");
                strSql2.Append("'" + model.BZ + "',");
            }
            if (model.PHBN != null)
            {
                strSql1.Append("PHBN,");
                strSql2.Append("'" + model.PHBN + "',");
            }
            if (model.ZF != null)
            {
                strSql1.Append("ZF,");
                strSql2.Append("'" + model.ZF + "',");
            }
            if (model.XS != null)
            {
                strSql1.Append("XS,");
                strSql2.Append("'" + model.XS + "',");
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
            strSql.Append("insert into fmd070(");
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
		public bool Update(Model.fmd070 model)
		{

            int rowsAffected = DbHelperMySql.ExecuteSql(Update_SQL(model));
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        public string Update_SQL(Model.fmd070 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update fmd070 set ");
            if (model.ZDRQ != null)
            {
                strSql.Append("ZDRQ='" + model.ZDRQ + "',");
            }
            else
            {
                strSql.Append("ZDRQ= null ,");
            }
            if (model.ZT != null)
            {
                strSql.Append("ZT='" + model.ZT + "',");
            }
            else
            {
                strSql.Append("ZT= null ,");
            }
            if (model.BL != null)
            {
                strSql.Append("BL='" + model.BL + "',");
            }
            else
            {
                strSql.Append("BL= null ,");
            }
            if (model.SYBH != null)
            {
                strSql.Append("SYBH='" + model.SYBH + "',");
            }
            else
            {
                strSql.Append("SYBH= null ,");
            }
            if (model.PZRBH != null)
            {
                strSql.Append("PZRBH='" + model.PZRBH + "',");
            }
            else
            {
                strSql.Append("PZRBH= null ,");
            }
            if (model.BZ != null)
            {
                strSql.Append("BZ='" + model.BZ + "',");
            }
            else
            {
                strSql.Append("BZ= null ,");
            }
            if (model.PHBN != null)
            {
                strSql.Append("PHBN='" + model.PHBN + "',");
            }
            else
            {
                strSql.Append("PHBN= null ,");
            }
            if (model.ZF != null)
            {
                strSql.Append("ZF='" + model.ZF + "',");
            }
            else
            {
                strSql.Append("ZF= null ,");
            }
            if (model.RLZBH != null)
            {
                strSql.Append("RLZBH='" + model.RLZBH + "',");
            }
            else
            {
                strSql.Append("RLZBH= null ,");
            }
            if (model.RLR != null)
            {
                strSql.Append("RLR='" + model.RLR + "',");
            }
            else
            {
                strSql.Append("RLR= null ,");
            }
            if (model.RLSJ != null)
            {
                strSql.Append("RLSJ='" + model.RLSJ + "',");
            }
            else
            {
                strSql.Append("RLSJ= null ,");
            }
            if (model.RLDMM != null)
            {
                strSql.Append("RLDMM='" + model.RLDMM + "',");
            }
            else
            {
                strSql.Append("RLDMM= null ,");
            }
            if (model.GXZBH != null)
            {
                strSql.Append("GXZBH='" + model.GXZBH + "',");
            }
            else
            {
                strSql.Append("GXZBH= null ,");
            }
            if (model.GXR != null)
            {
                strSql.Append("GXR='" + model.GXR + "',");
            }
            else
            {
                strSql.Append("GXR= null ,");
            }
            if (model.GXSJ != null)
            {
                strSql.Append("GXSJ='" + model.GXSJ + "',");
            }
            else
            {
                strSql.Append("GXSJ= null ,");
            }
            if (model.GXDMM != null)
            {
                strSql.Append("GXDMM='" + model.GXDMM + "',");
            }
            else
            {
                strSql.Append("GXDMM= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where CLBH='" + model.CLBH + "' and PHBBH='" + model.PHBBH + "' ");

            return strSql.ToString();
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CLBH,string PHBBH)
		{
            int rowsAffected = DbHelperMySql.ExecuteSql(Delete_SQL(CLBH, PHBBH));
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
        public string Delete_SQL(string CLBH, string PHBBH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fmd070 ");
            strSql.Append(" where CLBH='" + CLBH + "' and PHBBH='" + PHBBH + "' ");

            return strSql.ToString();
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd070 GetModel(string CLBH,string PHBBH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" CLBH,PHBBH,ZDRQ,ZT,BL,SYBH,PZRBH,BZ,PHBN,ZF,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM,XS ");
			strSql.Append(" from fmd070 ");
			strSql.Append(" where CLBH='"+CLBH+"' and PHBBH='"+PHBBH+"' " );
			Model.fmd070 model=new Model.fmd070();
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
		public Model.fmd070 DataRowToModel(DataRow row)
		{
			Model.fmd070 model=new Model.fmd070();
			if (row != null)
			{
				if(row["CLBH"]!=null)
				{
					model.CLBH=row["CLBH"].ToString();
				}
				if(row["PHBBH"]!=null)
				{
					model.PHBBH=row["PHBBH"].ToString();
				}
				if(row["ZDRQ"]!=null)
				{
					model.ZDRQ=row["ZDRQ"].ToString();
				}
				if(row["ZT"]!=null)
				{
					model.ZT=row["ZT"].ToString();
				}
				if(row["BL"]!=null)
				{
					model.BL=row["BL"].ToString();
				}
				if(row["SYBH"]!=null)
				{
					model.SYBH=row["SYBH"].ToString();
				}
				if(row["PZRBH"]!=null)
				{
					model.PZRBH=row["PZRBH"].ToString();
				}
				if(row["BZ"]!=null)
				{
					model.BZ=row["BZ"].ToString();
				}
				if(row["PHBN"]!=null)
				{
					model.PHBN=row["PHBN"].ToString();
				}
				if(row["ZF"]!=null)
				{
					model.ZF=row["ZF"].ToString();
				}
                if (row["XS"] != null)
                {
                    model.XS = Convert.ToDouble(row["XS"]);
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

            return GetList(strWhere,"");
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CLBH,PHBBH,ZDRQ,ZT,BL,SYBH,PZRBH,BZ,PHBN,ZF,XS,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
            strSql.Append(" FROM fmd070 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by " + orderby);
            }
            return DbHelperMySql.Query(strSql.ToString());
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM fmd070 ");
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
				strSql.Append("order by T.PHBBH desc");
			}
			strSql.Append(")AS Row, T.*  from fmd070 T ");
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
        /// 得到配合明细
        /// </summary>
        /// <param name="CLBH">材料编号</param>
        /// <param name="PHBBH">配合表编号</param>
        /// <param name="SL">数量</param>
        /// <param name="HLPCLOTNO">混炼批次号</param>
        /// <returns></returns>
        public DataTable GetPHMX(string CLBH, string PHBBH, string SL, string HLPCLOTNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Call UP_GetPHMX('" + CLBH + "','" + PHBBH + "','" + SL + "','" + HLPCLOTNO + "');");

            return DbHelperMySql.Query(strSql.ToString()).Tables[0];

        }

        public DataTable GetSpdData(string rqS,string rqE, string CLBH, string PHBBH, string ZCR, string PZR)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.CLBH,a.PHBBH,a.ZDRQ,YCLBH, c.ZSMC  JLDW,b.ZL,b.GC, d.symc SYBH,e.symc PZRBH,a.BZ,a.ZT FROM ");
            strSql.Append(" fmd070 a LEFT JOIN ");
            strSql.Append(" (SELECT * FROM fmd080 ) b ");
            strSql.Append(" ON (a.PHBBH=b.PHBBH) ");
            strSql.Append(" LEFT JOIN (select MCKEY,ZSMC from fmd000 where glbh='06')c on (b.jldw=c.MCKEY) ");
           strSql.Append("  left join (SELECT sybh,symc from fmd010 ) d on (a.SYBH=d.sybh) ");
           strSql.Append("  left join (SELECT sybh,symc from fmd010 ) e on (a.PZRBH=e.sybh) ");
            strSql.Append("  where 1=1            ");

            if (string.IsNullOrEmpty(rqS) == false)
            {
                strSql.Append("  and   a.ZDRQ>='"+rqS+"'           ");
            }


            if (string.IsNullOrEmpty(rqE) == false)
            {
                strSql.Append("  and   a.ZDRQ<='" + rqE + "'           ");
            }

            if (string.IsNullOrEmpty(CLBH) == false)
            {
                strSql.Append("  and   a.CLBH like '%" + CLBH + "%'           ");
            }
            
            if (string.IsNullOrEmpty(PHBBH) == false)
            {
                strSql.Append("  and   a.PHBBH like'%" + PHBBH + "%'           ");
            }
            if (string.IsNullOrEmpty(ZCR) == false)
            {
                strSql.Append("  and   a.SYBH ='" + ZCR + "'           ");
            }
            if (string.IsNullOrEmpty(PZR) == false)
            {
                strSql.Append("  and   a.PZRBH ='" + PZR + "'           ");
            }


            strSql.Append( " ORDER BY a.CLBH,a.PHBBH,a.ZDRQ, b.xss");



            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }

   
        /// <summary>
        /// 生成追番
        /// </summary>
        /// <param name="PHBN">配合表年</param>
        /// <returns></returns>
        public string GenerateZF(string PHBN)
        {
            string strSql = "select ifnull(max(zf),'0') + 1 as zf from FMD070 where  PHBN ='" + PHBN + "';";
            string zf = DbHelperMySql.GetSingle(strSql).ToString();

            return zf.PadLeft(3, '0');
        }

        /// <summary>
        /// 得到比例合计
        /// </summary>
        /// <param name="CLBH">材料编号</param>
        /// <returns></returns>
        public double GetSumBL(string CLBH)
        {
            string strSql = "select ifnull(sum(BL),1) as BL from FMD070 where CLBH='" + CLBH + "'";
            string bl = DbHelperMySql.GetSingle(strSql).ToString();

            return Convert.ToDouble(bl);
        }
        /// <summary>
        /// 得到配合表
        /// </summary>
        /// <param name="CLBH">材料编号</param>
        /// <returns></returns>
        public ArrayList GetPhbs(string CLBH)
        {
            ArrayList lstPhb = new ArrayList();
            string strSql = "select PHBBH from FMD070 where CLBH='" + CLBH + "'";
            DataTable myDt = DbHelperMySql.Query(strSql).Tables[0];

            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                lstPhb.Add(myDt.Rows[i]["PHBBH"]);
            }

            return lstPhb;
        }

        /// <summary>
        /// 更新系数
        /// </summary>
        /// <param name="phbbh"></param>
        /// <param name="sumXS"></param>
        /// <returns></returns>
        public string UpdateXsByPHB(string CLBH)
        {
            //string strSql = "Update FMD070 set XS=( BL / " + sumXS + " ) where PHBBH='" + phbbh + "'";
            //string strSql = "Update FMD070 set XS=( BL / ifnull(sum(BL),1)  ) where PHBBH='" + phbbh + "'";
            StringBuilder strSql = new StringBuilder();

             strSql.Append("update FMD070  a ");
             strSql.Append("left join (select CLBH,SUM(BL) SUM_BL from FMD070 group by CLBH) b ");
             strSql.Append("on a.CLBH=B.CLBH ");
             strSql.Append("set  a.XS = a.BL/b.SUM_BL  ");
             strSql.Append("where a.CLBH='" + CLBH + "' ");


            return strSql.ToString();
        }

        /// <summary>
        /// 得到配合表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public DataTable GetListByPBH(string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
   
            //strSql.Append(" select CLBH,PHBBH,ZDRQ,ZF, ");
            //strSql.Append(" case when ZT = '0' then '正常' else '已作废' end as ZT, ");
            //strSql.Append(" BL,SYBH,PZRBH,BZ  ");
            //strSql.Append(" from FMD070 ");

            strSql.Append(" select a.CLBH,a.PHBBH,a.ZDRQ, ZF,");
            strSql.Append(" case when a.ZT = '0' then '正常' else '已作废' end as ZT,  ");
            strSql.Append(" BL,a.SYBH, b.SYMC as ZZR,a.PZRBH,c.SYMC as PZR,a.BZ ");
            //strSql.Append(" BL,a.SYBH, ifnull(b.SYMC,a.SYBH) as ZZR,a.PZRBH,ifnull(c.SYMC,a.PZRBH) as PZR,a.BZ ");
            strSql.Append(" from FMD070 a ");
            strSql.Append(" left join fmd010 b on(a.SYBH = b.SYBH) ");
            strSql.Append(" left join fmd010 c on(a.PZRBH = c.SYBH) ");


            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by " + orderby);
            }

            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }



		#endregion  MethodEx
	}
}

