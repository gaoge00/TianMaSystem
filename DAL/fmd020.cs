/**  版本信息模板在安装目录下，可自行修改。
* fmd020.cs
*
* 功 能： N/A
* 类 名： fmd020
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:50   N/A    初版
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
	/// 数据访问类:fmd020
	/// </summary>
	public partial class fmd020
	{
		public fmd020()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string USERNAME,string PGID,string DMQF)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fmd020");
			strSql.Append(" where USERNAME='"+USERNAME+"' and PGID='"+PGID+"' and DMQF='"+DMQF+"' ");
			return DbHelperMySql.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.fmd020 model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.USERNAME != null)
			{
				strSql1.Append("USERNAME,");
				strSql2.Append("'"+model.USERNAME+"',");
			}
			if (model.PASSWORD != null)
			{
				strSql1.Append("PASSWORD,");
				strSql2.Append("'"+model.PASSWORD+"',");
			}
			if (model.PGID != null)
			{
				strSql1.Append("PGID,");
				strSql2.Append("'"+model.PGID+"',");
			}
			if (model.DMQF != null)
			{
				strSql1.Append("DMQF,");
				strSql2.Append("'"+model.DMQF+"',");
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
			strSql.Append("insert into fmd020(");
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
		public bool Update(Model.fmd020 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fmd020 set ");
			if (model.PASSWORD != null)
			{
				strSql.Append("PASSWORD='"+model.PASSWORD+"',");
			}
			else
			{
				strSql.Append("PASSWORD= null ,");
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
			strSql.Append(" where USERNAME='"+ model.USERNAME+"' and PGID='"+ model.PGID+"' and DMQF='"+ model.DMQF+"' ");
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
		public bool Delete(string USERNAME,string PGID,string DMQF)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fmd020 ");
			strSql.Append(" where USERNAME='"+USERNAME+"' and PGID='"+PGID+"' and DMQF='"+DMQF+"' " );
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
		public Model.fmd020 GetModel(string USERNAME,string PGID,string DMQF)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" USERNAME,PASSWORD,PGID,DMQF,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" from fmd020 ");
			strSql.Append(" where USERNAME='"+USERNAME+"' and PGID='"+PGID+"' and DMQF='"+DMQF+"' " );
			Model.fmd020 model=new Model.fmd020();
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
		public Model.fmd020 DataRowToModel(DataRow row)
		{
			Model.fmd020 model=new Model.fmd020();
			if (row != null)
			{
				if(row["USERNAME"]!=null)
				{
					model.USERNAME=row["USERNAME"].ToString();
				}
				if(row["PASSWORD"]!=null)
				{
					model.PASSWORD=row["PASSWORD"].ToString();
				}
				if(row["PGID"]!=null)
				{
					model.PGID=row["PGID"].ToString();
				}
				if(row["DMQF"]!=null)
				{
					model.DMQF=row["DMQF"].ToString();
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
			strSql.Append("select USERNAME,PASSWORD,PGID,DMQF,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" FROM fmd020 ");
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
			strSql.Append("select count(1) FROM fmd020 ");
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
				strSql.Append("order by T.DMQF desc");
			}
			strSql.Append(")AS Row, T.*  from fmd020 T ");
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

        /// <summary>
        /// Login 画面验证用户名密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable YongHuMima_GetYM(string username, string password)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("select distinct username ,password from fmd020 ");
            StrSQL.Append("where username='" + username + "' and password = '" + password + "'");
            return DbHelperMySql.Query(StrSQL.ToString()).Tables[0];
        }

        /// <summary>
        /// Login 画面验证用户名是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable YongHuMima_GetCorN(string username)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("select distinct a.username username,b.SYMC XM ");
            StrSQL.Append("from fmd020 a ");
            StrSQL.Append("left join fmd010 b on (a.username = b.sybh) ");
            StrSQL.Append("where a.username ='" + username + "' and b.ZT = '1' ");

            return DbHelperMySql.Query(StrSQL.ToString()).Tables[0];
        }

        /// <summary>
        /// 判断登录是否成功
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="password"></param>
        /// <param name="dmqf"></param>
        /// <returns></returns>
        public bool CheckLogin(string uid, string password, string dmqf)
        {
            string strSql = "Select Count(*) from FMD020 where DMQF='" + dmqf + "' and USERNAME='" + uid + "' and PASSWORD='" + password + "'";

            return DbHelperMySql.Exists(strSql);
        }



        /// <summary>
        /// 权限查找对应权限(表头)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetProject_SelectQX(string DMQF)
        {
            StringBuilder strSql = new StringBuilder();
            if (DMQF.Equals("0") == true)
            {
                strSql.Append("select a.M_ID,a.M_NAME,b.P_NAME,b.P_PorName from MenuPro a ");
                strSql.Append("left join Project b on a.M_ID = b.M_P_ID ");
                strSql.Append("where a.DMQF ='" + DMQF + "' and IFNULL(P_NAME,'')  <>''");
                strSql.Append("order by b.M_P_ID,b.P_order ");
            }


            if (DMQF.Equals("1") == true)
            {
                strSql.Append("   select a.M_ID,a.M_NAME P_NAME from MenuPro a ");
              strSql.Append("where a.DMQF ='" + DMQF + "' and IFNULL(M_NAME,'')  <>'' ");
            }


            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 权限 获取用户名密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetQuanxian_SpdGetXM(string DMQF)
        {
            StringBuilder StrSQL = new StringBuilder();
           // StrSQL.Append("SELECT DISTINCT a.USERNAME,b.XM,a.PASSWORD,b.TSRQ FROM FMD020 a LEFT JOIN FMD310 b ON a.USERNAME = b.SYBH ");
           //// StrSQL.Append(" where b.scqf <>'1' ");
           // StrSQL.Append("ORDER BY IFNULL(b.TSRQ,''),a.USERNAME ");

            
           StrSQL.Append("SELECT DISTINCT a.USERNAME,b.SYMC XM,a.PASSWORD,ZT TSQF FROM FMD020 a ");
           StrSQL.Append("LEFT JOIN FMD010 b ON a.USERNAME = b.SYBH where a.DMQF='"+DMQF+"' ORDER BY a.USERNAME  ");


            return DbHelperMySql.Query(StrSQL.ToString()).Tables[0];
        }


        /// <summary>
        /// 权限表去用户权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetQuanxian_YongHu(Model.fmd020 model)
        {
            StringBuilder StrSQL = new StringBuilder();
            if (model.DMQF.Equals("0") == true)
            {
                StrSQL.Append("select a.pgid,b.p_name from FMD020 a left join Project b on a.pgid = b.p_porname ");
                StrSQL.Append("where a.username = '" + model.USERNAME + "' and a.DMQF='" + model.DMQF + "'");
            }
            else
            {


                StrSQL.Append("  select a.pgid,b.M_NAME  p_name from FMD020 a left join menupro b on a.pgid = b.M_ID ");
                StrSQL.Append("   where a.username = '" + model.USERNAME + "' and a.DMQF='" + model.DMQF + "' ");
            }
            return DbHelperMySql.Query(StrSQL.ToString()).Tables[0];
        }


        /// <summary>
        /// 判断当前表头是否匹配中文
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetProject_TitleTF(string P_NAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_NAME,P_PorName from Project ");
            strSql.Append("where P_NAME = '" + P_NAME + "' order by P_order");
            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }



        /// <summary>
        /// 删除用户权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string DeleteYongHuQX(string Username, string DMQF)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("delete from FMD020 where USERNAME ='" + Username + "'  and DMQF='"+DMQF+"'");
            return StrSQL.ToString();
        }

        /// <summary>
        /// 用户名密码为空删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string DdeleteYongHu_KongYM(Model.fmd020 model)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("delete from FMD020 ");
            StrSQL.Append("where username = '" + model.USERNAME + "' and DMQF='"+model.DMQF+"' ");
            return StrSQL.ToString();
        }

        /// <summary>
        /// 插入用户权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string InsertUserInfo(Model.fmd020 model)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("INSERT INTO FMD020(USERNAME,PASSWORD,PGID,DMQF,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM) ");
            StrSQL.Append("VALUES('" + model.USERNAME + "','" + model.PASSWORD + "','" + model.PGID + "','"+model.DMQF+"','" + model.RLZBH + "','" + model.RLR + "','" + model.RLSJ + "','" + model.RLDMM + "','" + model.GXZBH + "','" + model.GXR + "','" + model.GXSJ + "','" + model.GXZBH + "')");
            return StrSQL.ToString();
        }

        /// <summary>
        ///  删除用户权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string DeleteUserInfo(string DMQF)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("delete from FMD020 where DMQF='"+DMQF+"' ");
            return StrSQL.ToString();
        }

        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        /// <param name="sybh"></param>
        /// <returns></returns>
        public DataTable Select_SybhIsExit(string sybh)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("select SYMC XM,ZT TSRQ from FMD010 where SYBH='" + sybh + "' ");
            StrSQL.Append("and ifnull(zt,'') <>'0' ");
            return DbHelperMySql.Query(StrSQL.ToString()).Tables[0];

        }

         public void Update_Pass(string strPass,string strUSERID)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("  UPDATE  fmd020 SET `PASSWORD`='" + strPass + "' where USERNAME='" + strUSERID + "' ");
            DbHelperMySql.Query(StrSQL.ToString());
         }
	}
}

