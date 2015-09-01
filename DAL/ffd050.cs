/**  版本信息模板在安装目录下，可自行修改。
* ffd050.cs
*
* 功 能： N/A
* 类 名： ffd050
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
using System.Collections.Generic;
//using DBUtility;//Please add references
namespace DAL
{
    /// <summary>
    /// 数据访问类:ffd050
    /// </summary>
    public partial class ffd050
    {
        public ffd050()
        { }
        #region  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CKZLBH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ffd050");
            strSql.Append(" where CKZLBH='" + CKZLBH + "' ");
            return DbHelperMySql.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.ffd050 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.CKZLBH != null)
            {
                strSql1.Append("CKZLBH,");
                strSql2.Append("'" + model.CKZLBH + "',");
            }
            if (model.CKRQ != null)
            {
                strSql1.Append("CKRQ,");
                strSql2.Append("'" + model.CKRQ + "',");
            }
            if (model.CLBH != null)
            {
                strSql1.Append("CLBH,");
                strSql2.Append("'" + model.CLBH + "',");
            }
            if (model.PM != null)
            {
                strSql1.Append("PM,");
                strSql2.Append("'" + model.PM + "',");
            }
            if (model.PH != null)
            {
                strSql1.Append("PH,");
                strSql2.Append("'" + model.PH + "',");
            }
            if (model.KHBH != null)
            {
                strSql1.Append("KHBH,");
                strSql2.Append("'" + model.KHBH + "',");
            }
            if (model.ZF != null)
            {
                strSql1.Append("ZF,");
                strSql2.Append("'" + model.ZF + "',");
            }
            if (model.DJ != null)
            {
                strSql1.Append("DJ,");
                strSql2.Append("" + model.DJ + ",");
            }
            if (model.ZSSLHJ != null)
            {
                strSql1.Append("ZSSLHJ,");
                strSql2.Append("" + model.ZSSLHJ + ",");
            }
            if (model.ZSXS != null)
            {
                strSql1.Append("ZSXS,");
                strSql2.Append("" + model.ZSXS + ",");
            }
            if (model.ZSDDS != null)
            {
                strSql1.Append("ZSDDS,");
                strSql2.Append("" + model.ZSDDS + ",");
            }
            if (model.ZSXDS != null)
            {
                strSql1.Append("ZSXDS,");
                strSql2.Append("" + model.ZSXDS + ",");
            }
            if (model.CKZLXDZ != null)
            {
                strSql1.Append("CKZLXDZ,");
                strSql2.Append("'" + model.CKZLXDZ + "',");
            }
            if (model.CKDDZ != null)
            {
                strSql1.Append("CKDDZ,");
                strSql2.Append("'" + model.CKDDZ + "',");
            }
            if (model.CKWCS != null)
            {
                strSql1.Append("CKWCS,");
                strSql2.Append("" + model.CKWCS + ",");
            }
            if (model.WCQF != null)
            {
                strSql1.Append("WCQF,");
                strSql2.Append("'" + model.WCQF + "',");
            }
            if (model.BZ != null)
            {
                strSql1.Append("BZ,");
                strSql2.Append("'" + model.BZ + "',");
            }
            if (model.DMQF != null)
            {
                strSql1.Append("DMQF,");
                strSql2.Append("'" + model.DMQF + "',");
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
            if (model.CKZLRQ != null)
            {
                strSql1.Append("CKZLRQ,");
                strSql2.Append("'" + model.CKZLRQ + "',");
            }

            strSql.Append("insert into ffd050(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            int rows = DbHelperMySql.ExecuteSql(strSql.ToString());
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
        public bool Update(Model.ffd050 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ffd050 set ");
            if (model.CKRQ != null)
            {
                strSql.Append("CKRQ='" + model.CKRQ + "',");
            }
            else
            {
                strSql.Append("CKRQ= null ,");
            }
            if (model.CLBH != null)
            {
                strSql.Append("CLBH='" + model.CLBH + "',");
            }
            else
            {
                strSql.Append("CLBH= null ,");
            }
            if (model.PM != null)
            {
                strSql.Append("PM='" + model.PM + "',");
            }
            else
            {
                strSql.Append("PM= null ,");
            }
            if (model.PH != null)
            {
                strSql.Append("PH='" + model.PH + "',");
            }
            else
            {
                strSql.Append("PH= null ,");
            }
            if (model.KHBH != null)
            {
                strSql.Append("KHBH='" + model.KHBH + "',");
            }
            else
            {
                strSql.Append("KHBH= null ,");
            }

            if (model.ZF != null)
            {
                strSql.Append("ZF='" + model.ZF + "',");
            }
            else
            {
                strSql.Append("ZF= null ,");
            }

            if (model.DJ != null)
            {
                strSql.Append("DJ=" + model.DJ + ",");
            }
            else
            {
                strSql.Append("DJ= null ,");
            }
            if (model.ZSSLHJ != null)
            {
                strSql.Append("ZSSLHJ=" + model.ZSSLHJ + ",");
            }
            else
            {
                strSql.Append("ZSSLHJ= null ,");
            }
            if (model.ZSXS != null)
            {
                strSql.Append("ZSXS=" + model.ZSXS + ",");
            }
            else
            {
                strSql.Append("ZSXS= null ,");
            }
            if (model.ZSDDS != null)
            {
                strSql.Append("ZSDDS=" + model.ZSDDS + ",");
            }
            else
            {
                strSql.Append("ZSDDS= null ,");
            }
            if (model.ZSXDS != null)
            {
                strSql.Append("ZSXDS=" + model.ZSXDS + ",");
            }
            else
            {
                strSql.Append("ZSXDS= null ,");
            }
            if (model.CKZLXDZ != null)
            {
                strSql.Append("CKZLXDZ='" + model.CKZLXDZ + "',");
            }
            else
            {
                strSql.Append("CKZLXDZ= null ,");
            }
            if (model.CKDDZ != null)
            {
                strSql.Append("CKDDZ='" + model.CKDDZ + "',");
            }
            else
            {
                strSql.Append("CKDDZ= null ,");
            }
            if (model.CKWCS != null)
            {
                strSql.Append("CKWCS=" + model.CKWCS + ",");
            }
            else
            {
                strSql.Append("CKWCS= null ,");
            }
            if (model.WCQF != null)
            {
                strSql.Append("WCQF='" + model.WCQF + "',");
            }
            else
            {
                strSql.Append("WCQF= null ,");
            }
            if (model.BZ != null)
            {
                strSql.Append("BZ='" + model.BZ + "',");
            }
            else
            {
                strSql.Append("BZ= null ,");
            }
            if (model.DMQF != null)
            {
                strSql.Append("DMQF='" + model.DMQF + "',");
            }
            else
            {
                strSql.Append("DMQF= null ,");
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
            if (model.CKZLRQ != null)
            {
                strSql.Append("CKZLRQ='" + model.CKZLRQ + "',");
            }
            else
            {
                strSql.Append("CKZLRQ= null ,");
            }

            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where CKZLBH='" + model.CKZLBH + "' ");
            int rowsAffected = DbHelperMySql.ExecuteSql(strSql.ToString());
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
        public bool Delete(string CKZLBH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ffd050 ");
            strSql.Append(" where CKZLBH='" + CKZLBH + "' ");
            int rowsAffected = DbHelperMySql.ExecuteSql(strSql.ToString());
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
        public bool DeleteList(string CKZLBHlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ffd050 ");
            strSql.Append(" where CKZLBH in (" + CKZLBHlist + ")  ");
            int rows = DbHelperMySql.ExecuteSql(strSql.ToString());
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
        public Model.ffd050 GetModel(string CKZLBH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" CKZLBH,CKRQ,CLBH,PM,PH,KHBH,ZF,DJ,ZSSLHJ,ZSXS,ZSDDS,ZSXDS,CKZLXDZ,CKDDZ,CKWCS,WCQF,BZ,DMQF,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM,CKZLRQ ");
            strSql.Append(" from ffd050 ");
            strSql.Append(" where CKZLBH='" + CKZLBH + "' ");
            Model.ffd050 model = new Model.ffd050();
            DataSet ds = DbHelperMySql.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
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
        public Model.ffd050 DataRowToModel(DataRow row)
        {
            Model.ffd050 model = new Model.ffd050();
            if (row != null)
            {
                if (row["CKZLBH"] != null)
                {
                    model.CKZLBH = row["CKZLBH"].ToString();
                }
                if (row["CKRQ"] != null)
                {
                    model.CKRQ = row["CKRQ"].ToString();
                }
                if (row["CKZLRQ"] != null)
                {
                    model.CKZLRQ = row["CKZLRQ"].ToString();
                }
                if (row["CLBH"] != null)
                {
                    model.CLBH = row["CLBH"].ToString();
                }
                if (row["PM"] != null)
                {
                    model.PM = row["PM"].ToString();
                }
                if (row["PH"] != null)
                {
                    model.PH = row["PH"].ToString();
                }
                if (row["ZF"] != null)
                {
                    model.ZF = row["ZF"].ToString();
                }
                if (row["KHBH"] != null)
                {
                    model.KHBH = row["KHBH"].ToString();
                }
                if (row["DJ"] != null && row["DJ"].ToString() != "")
                {
                    model.DJ = decimal.Parse(row["DJ"].ToString());
                }
                if (row["ZSSLHJ"] != null && row["ZSSLHJ"].ToString() != "")
                {
                    model.ZSSLHJ = int.Parse(row["ZSSLHJ"].ToString());
                }
                if (row["ZSXS"] != null && row["ZSXS"].ToString() != "")
                {
                    model.ZSXS = int.Parse(row["ZSXS"].ToString());
                }
                if (row["ZSDDS"] != null && row["ZSDDS"].ToString() != "")
                {
                    model.ZSDDS = int.Parse(row["ZSDDS"].ToString());
                }
                if (row["ZSXDS"] != null && row["ZSXDS"].ToString() != "")
                {
                    model.ZSXDS = int.Parse(row["ZSXDS"].ToString());
                }
                if (row["CKZLXDZ"] != null)
                {
                    model.CKZLXDZ = row["CKZLXDZ"].ToString();
                }
                if (row["CKDDZ"] != null)
                {
                    model.CKDDZ = row["CKDDZ"].ToString();
                }
                if (row["CKWCS"] != null && row["CKWCS"].ToString() != "")
                {
                    model.CKWCS = int.Parse(row["CKWCS"].ToString());
                }
                if (row["WCQF"] != null)
                {
                    model.WCQF = row["WCQF"].ToString();
                }
                if (row["BZ"] != null)
                {
                    model.BZ = row["BZ"].ToString();
                }
                if (row["DMQF"] != null)
                {
                    model.DMQF = row["DMQF"].ToString();
                }
                if (row["RLZBH"] != null)
                {
                    model.RLZBH = row["RLZBH"].ToString();
                }
                if (row["RLR"] != null)
                {
                    model.RLR = row["RLR"].ToString();
                }
                if (row["RLSJ"] != null)
                {
                    model.RLSJ = row["RLSJ"].ToString();
                }
                if (row["RLDMM"] != null)
                {
                    model.RLDMM = row["RLDMM"].ToString();
                }
                if (row["GXZBH"] != null)
                {
                    model.GXZBH = row["GXZBH"].ToString();
                }
                if (row["GXR"] != null)
                {
                    model.GXR = row["GXR"].ToString();
                }
                if (row["GXSJ"] != null)
                {
                    model.GXSJ = row["GXSJ"].ToString();
                }
                if (row["GXDMM"] != null)
                {
                    model.GXDMM = row["GXDMM"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CKZLBH,CKRQ,CLBH,PM,PH,KHBH,ZF,DJ,ZSSLHJ,ZSXS,ZSDDS,ZSXDS,CKZLXDZ,CKDDZ,CKWCS,WCQF,BZ,DMQF,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM,CKZLRQ ");
            strSql.Append(" FROM ffd050 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySql.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ffd050 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.CKZLBH desc");
            }
            strSql.Append(")AS Row, T.*  from ffd050 T ");
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
        /// 获得绑定CboBox的出库指令数据
        /// </summary>
        /// <returns></returns>
        public DataTable getAllCKZLBH_CBOX(string CKZLRQ, string WCQF)
        {
            DataTable dtResult = new DataTable();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select CKZLBH ZSMC, CKZLBH MCKEY  from FFD050 ");
            strSQL.Append("where 1=1   ");
            if (!string.IsNullOrEmpty(CKZLRQ))
            strSQL.Append(" and CKZLRQ='" + CKZLRQ + "'  ");
            if (!string.IsNullOrEmpty(WCQF))
            strSQL.Append(" and WCQF='" + WCQF + "'  ");

            strSQL.Append("order by WCQF desc ; ");
            dtResult = DbHelperMySql.Query(strSQL.ToString()).Tables[0];
            return dtResult;
        }

        /// <summary>
        /// 获得绑定CboBox的出库指令数据
        /// </summary>
        /// <returns></returns>
        public DataTable getAllCKZLBH_CBOX()
        {
            DataTable dtResult = new DataTable();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select CKZLBH ZSMC, CKZLBH MCKEY from FFD050 ");
            strSQL.Append("order by WCQF desc ; ");
            dtResult = DbHelperMySql.Query(strSQL.ToString()).Tables[0];
            return dtResult;
        }


        /// <summary>
        /// 获得绑定CboBox的出库指令数据
        /// </summary>
        /// <returns></returns>
        public DataTable getCKZLBH_Info(string CKZLBH)
        {
            DataTable dtResult = new DataTable();
            StringBuilder strSQL = new StringBuilder();

            strSQL.Append("call UP_GetCKZLBHInfo('" + CKZLBH + "'); ");
            //strSQL.Append("select a.CLBH,a.PM,a.PH,a.ZSSLHJ,a.CKRQ, ");
            //strSQL.Append("a.ZSXS,b.XSLBZ,a.ZSDDS,b.DDSLBZ,a.ZSXDS,b.XDSLBZ, ");
            //strSQL.Append("Concat((a.ZSSLHJ-a.CKWCS)/b.XSLBZ,'箱,', ");
            //strSQL.Append("           ((a.ZSSLHJ-a.CKWCS)%b.XSLBZ)/b.DDSLBZ,'大袋,', ");
            //strSQL.Append("           (((a.ZSSLHJ-a.CKWCS)%b.XSLBZ)%b.DDSLBZ)/b.XDSLBZ) CKCTJ, ");
            //strSQL.Append("a.ZSSLHJ-a.CKWCS CKCS, ");
            //strSQL.Append("Concat(a.CKDDZ,'    ',c.SYBH) CKR, ");
            //strSQL.Append("b.XQF  ");
            //strSQL.Append("from ffd050 a ");
            //strSQL.Append("left join (select CLBH,PM,PH,XDSLBZ,DDSLBZ,XSLBZ,XQF from fmd060) b ");
            //strSQL.Append("on a.CLBH=b.CLBH and a.PM=b.PM and a.PH=b.PH ");
            //strSQL.Append("left join (select SYBH,SYMC from FMD010) c ");
            //strSQL.Append("on a.CKDDZ=c.SYBH ");
            //strSQL.Append("where WCQF='0' ");
            //strSQL.Append("and CKZLBH='" + CKZLBH + "' ");
            //strSQL.Append("order by CKRQ ; ");
            dtResult = DbHelperMySql.Query(strSQL.ToString()).Tables[0];
            return dtResult;
        }

        /// <summary>
        /// 获得绑定CboBox的出库指令数据
        /// </summary>
        /// <returns></returns>
        public bool SaveWLCK(Model.ffd050 modelFFD050, List<string> listStrX, List<string> listStrDD, List<string> listStrXD)
        {
            List<string> listStrSQL = new List<string>();
            StringBuilder strSQL = new StringBuilder();

            strSQL.Append("delete from ffd070 ");
            strSQL.Append("where CKZLBH='" + modelFFD050.CKZLBH + "'; ");
            listStrSQL.Add(strSQL.ToString());

            //修改订单时，先将原有数据清空
            strSQL = new StringBuilder();
            strSQL.Append("update ffd020 ");
            strSQL.Append("set CKRBH=NULL ");
            strSQL.Append("   ,CKWCQF='0' ");
            strSQL.Append("   ,DMQF='" + modelFFD050.DMQF + "' ");
            strSQL.Append("   ,CKZLBH=NULL ");
            strSQL.Append("   ,CKRQ=NULL ");
            strSQL.Append(" where CKZLBH='" + modelFFD050.CKZLBH + "' ");
            listStrSQL.Add(strSQL.ToString());

            strSQL = new StringBuilder();
            strSQL.Append("update ffd050 ");
            strSQL.Append("set CKRQ='" + modelFFD050.CKRQ + "' ");
            strSQL.Append("   ,CKDDZ='" + modelFFD050.CKDDZ + "' ");
            strSQL.Append("   ,CKWCS=" + modelFFD050.CKWCS + " ");
            strSQL.Append("   ,WCQF='" + modelFFD050.WCQF + "' ");
            strSQL.Append("   ,DMQF='" + modelFFD050.DMQF + "' ");
            strSQL.Append("   ,GXZBH='" + modelFFD050.GXZBH + "' ");
            strSQL.Append("   ,GXR='" + modelFFD050.GXR + "' ");
            strSQL.Append("   ,GXSJ='" + modelFFD050.GXSJ + "' ");
            strSQL.Append("   ,GXDMM='" + modelFFD050.GXDMM + "' ");
            strSQL.Append("   where CKZLBH='" + modelFFD050.CKZLBH + "'; ");
            listStrSQL.Add(strSQL.ToString());

            strSQL = new StringBuilder();
            string strXLotNO = spliceStrLotNO(listStrX).Trim();
            string strDDLotNO = spliceStrLotNO(listStrDD).Trim();
            string strXDLotNO = spliceStrLotNO(listStrXD).Trim();

            if (!string.IsNullOrEmpty(strXLotNO) || 
                !string.IsNullOrEmpty(strDDLotNO) || 
                !string.IsNullOrEmpty(strXDLotNO))
            {
                strSQL.Append("update ffd020 ");
                strSQL.Append("set CKRBH='" + modelFFD050.CKDDZ + "' ");
                strSQL.Append("   ,CKWCQF='1' ");
                strSQL.Append("   ,DMQF='" + modelFFD050.DMQF + "' ");
                strSQL.Append("   ,CKZLBH='" + modelFFD050.CKZLBH + "' ");
                strSQL.Append("   ,CKRQ='" + modelFFD050.CKRQ + "' ");
                strSQL.Append(" where 1<>1 ");
                if (!string.IsNullOrEmpty(strXLotNO))
                {
                    strSQL.Append("or XLOTNO in (" + strXLotNO + ") ");
                }
                if (!string.IsNullOrEmpty(strDDLotNO))
                {
                    strSQL.Append("or DDLOTNO in (" + strDDLotNO + ") ");
                }
                if (!string.IsNullOrEmpty(strXDLotNO))
                {
                    strSQL.Append("or XDLOTNO in (" + strXDLotNO + ") ");
                }
                listStrSQL.Add(strSQL.ToString());
            }
            

            if (!string.IsNullOrEmpty(strXLotNO))
            {
                strSQL = new StringBuilder();
                strSQL.Append(" insert into ffd070 ");
                strSQL.Append(" select distinct   ");
                strSQL.Append(" '" + modelFFD050.CKZLBH + "', ");
                strSQL.Append("   XLOTNO, ");
                strSQL.Append(" '" + modelFFD050.CKRQ + "', ");
                strSQL.Append("  substring(XLOTNO,4,1), ");
                strSQL.Append("  substring(XLOTNO, LOCATE(',',XLOTNO)+1), ");
                strSQL.Append(" '" + modelFFD050.CKDDZ + "', ");
                strSQL.Append(" '" + modelFFD050.GXZBH + "', ");
                strSQL.Append(" '" + modelFFD050.GXR + "', ");
                strSQL.Append(" '" + modelFFD050.GXSJ + "', ");
                strSQL.Append(" '" + modelFFD050.GXDMM + "', ");
                strSQL.Append(" NULL GXZBH, ");
                strSQL.Append(" NULL GXR, ");
                strSQL.Append(" NULL GXSJ, ");
                strSQL.Append(" NULL GXDMM ");
                strSQL.Append(" from ffd020 ");
                strSQL.Append("where 1=1 ");
                strSQL.Append("and XLOTNO in (" + strXLotNO + ") ");
                listStrSQL.Add(strSQL.ToString());
            }
            if (!string.IsNullOrEmpty(strDDLotNO))
            {
                strSQL = new StringBuilder();
                strSQL.Append(" insert into ffd070 ");
                strSQL.Append(" select distinct   ");
                strSQL.Append(" '" + modelFFD050.CKZLBH + "', ");
                strSQL.Append("   DDLOTNO, ");
                strSQL.Append(" '" + modelFFD050.CKRQ + "', ");
                strSQL.Append("  substring(DDLOTNO,4,1), ");
                strSQL.Append("  substring(DDLOTNO, LOCATE(',',DDLOTNO)+1), ");
                strSQL.Append(" '" + modelFFD050.CKDDZ + "', ");
                strSQL.Append(" '" + modelFFD050.GXZBH + "', ");
                strSQL.Append(" '" + modelFFD050.GXR + "', ");
                strSQL.Append(" '" + modelFFD050.GXSJ + "', ");
                strSQL.Append(" '" + modelFFD050.GXDMM + "', ");
                strSQL.Append(" NULL, ");
                strSQL.Append(" NULL, ");
                strSQL.Append(" NULL, ");
                strSQL.Append(" NULL ");
                strSQL.Append(" from ffd020 ");
                strSQL.Append("where 1=1 ");
                strSQL.Append("and DDLOTNO in (" + strDDLotNO + ") ");
                listStrSQL.Add(strSQL.ToString());
            }
            if (!string.IsNullOrEmpty(strXDLotNO))
            {
                strSQL = new StringBuilder();
                strSQL.Append(" insert into ffd070 ");
                strSQL.Append(" select distinct   ");
                strSQL.Append(" '" + modelFFD050.CKZLBH + "', ");
                strSQL.Append("   XDLOTNO, ");
                strSQL.Append(" '" + modelFFD050.CKRQ + "', ");
                strSQL.Append("  substring(XDLOTNO,4,1), ");
                strSQL.Append("  substring(XDLOTNO, LOCATE(',',XDLOTNO)+1), ");
                strSQL.Append(" '" + modelFFD050.CKDDZ + "', ");
                strSQL.Append(" '" + modelFFD050.GXZBH + "', ");
                strSQL.Append(" '" + modelFFD050.GXR + "', ");
                strSQL.Append(" '" + modelFFD050.GXSJ + "', ");
                strSQL.Append(" '" + modelFFD050.GXDMM + "', ");
                strSQL.Append(" NULL, ");
                strSQL.Append(" NULL, ");
                strSQL.Append(" NULL, ");
                strSQL.Append(" NULL ");
                strSQL.Append(" from ffd020 ");
                strSQL.Append("where 1=1 ");
                strSQL.Append("and XDLOTNO in (" + strXDLotNO + ") ");
                listStrSQL.Add(strSQL.ToString());
            }

            int iRet = DbHelperMySql.ExecuteSqlTran(listStrSQL);
            return iRet == -1 ? false : true;

            //return listStrSQL;

        }

        /// <summary>
        /// 得到拼接的LotNO
        /// </summary>
        /// <param name="listStr"></param>
        /// <returns></returns>
        private string spliceStrLotNO(List<string> listStr)
        {
            StringBuilder strSplice = new StringBuilder();
            if (listStr.Count > 0)
            {
                foreach (string str in listStr)
                {
                    strSplice.Append("'" + str + "',");
                }
                if (strSplice.Length > 0)
                {
                    strSplice = strSplice.Remove(strSplice.Length - 1, 1);
                }
            }
            return strSplice.ToString();
        }

        /// <summary>
        /// 根据本次应出的数量，推算出应出的箱LOT，大袋LOT，小袋LOT
        /// </summary>
        /// <param name="CKZLBH">出库指令编号</param>
        /// <returns></returns>
        public DataTable getLLCK(string CKZLBH,int Xnum, int DDnum, int XDnum)
        {
            //DataTable dtResult=new DataTable();
            //StringBuilder strSQL = new StringBuilder();
            //strSQL.Append(" select distinct LOTNO ,TXMQF QF  from ffd060                                           ");
            //strSQL.Append(" where ifnull(CKZLBH,'')='" + CKZLBH + "'                           ");
            //strSQL.Append(" order by TXMQF desc,LOTNO                                                                       ");
            //dtResult = DbHelperMySql.Query(strSQL.ToString()).Tables[0];
            //return dtResult;

            DataTable dtResult = new DataTable();
            StringBuilder strSQL = new StringBuilder();
            DataTable dtX = new DataTable();
            DataTable dtDD = new DataTable();
            DataTable dtXD = new DataTable();
            strSQL.Append(" select distinct XLOTNO LOTNO,'3' QF  from ffd020 a                                          ");
            strSQL.Append(" left join (                                          ");
			strSQL.Append(" select a.CKZLBH,b.ID,b.LHRQ from ffd050 a                                          ");
			strSQL.Append(" left join (select ID,LHRQ,PM,PH,CLBH from ffd010) b                                          ");
            strSQL.Append(" on a.PM=b.PM and a.PH=b.PH and a.CLBH=b.CLBH	                                          ");		
            strSQL.Append(" ) b                                              ");
            strSQL.Append(" on a.ID=b.ID                                                                          ");
            strSQL.Append(" where ifnull(XLOTNO,'')<>'' and  ifnull(a.CKWCQF,'0')<>'1'                            ");
            strSQL.Append(" and b.CKZLBH='" + CKZLBH + "'                                                                     ");
            strSQL.Append(" order by b.LHRQ,a.XINTZF                                                                       ");
            strSQL.Append(" limit " + Xnum + "                                                                               ");
            dtX = DbHelperMySql.Query(strSQL.ToString()).Tables[0];
            string strX = string.Empty;
            for (int i = 0; i < dtX.Rows.Count; i++)
            {
                strX += "'" + dtX.Rows[i]["LOTNO"] + "',";
            }
            strX = strX.Length > 0 ? strX.Remove(strX.Length - 1) : strX;
            strSQL = new StringBuilder();
            strSQL.Append(" select distinct DDLOTNO LOTNO,'2' QF  from ffd020 a                                          ");
            strSQL.Append(" left join (                                          ");
            strSQL.Append(" select a.CKZLBH,b.ID,b.LHRQ from ffd050 a                                          ");
            strSQL.Append(" left join (select ID,LHRQ,PM,PH,CLBH from ffd010) b                                          ");
            strSQL.Append(" on a.PM=b.PM and a.PH=b.PH and a.CLBH=b.CLBH	                                          ");
            strSQL.Append(" ) b                                              ");
            strSQL.Append(" on a.ID=b.ID                                                                          ");
            strSQL.Append(" where ifnull(DDLOTNO,'')<>'' and  ifnull(a.CKWCQF,'0')<>'1'                            ");
            strSQL.Append(" and b.CKZLBH='" + CKZLBH + "'                                                                     ");
            if (!string.IsNullOrEmpty(strX))
                strSQL.Append(" and ifnull(XLOTNO,'') not in (" + strX + ")                                            ");
            strSQL.Append(" order by b.LHRQ,a.DDINTZF                                                                       ");
            strSQL.Append(" limit " + DDnum + "                                                                               ");
            dtDD = DbHelperMySql.Query(strSQL.ToString()).Tables[0];
            string strDD = string.Empty;
            for (int i = 0; i < dtDD.Rows.Count; i++)
            {
                strDD += "'" + dtDD.Rows[i]["LOTNO"] + "',";
            }
            strDD = strDD.Length > 0 ? strDD.Remove(strDD.Length - 1) : strDD;
            strSQL = new StringBuilder();
            strSQL.Append(" select distinct XDLOTNO LOTNO,'1' QF  from ffd020 a                                          ");
            strSQL.Append(" left join (                                          ");
            strSQL.Append(" select a.CKZLBH,b.ID,b.LHRQ from ffd050 a                                          ");
            strSQL.Append(" left join (select ID,LHRQ,PM,PH,CLBH from ffd010) b                                          ");
            strSQL.Append(" on a.PM=b.PM and a.PH=b.PH and a.CLBH=b.CLBH	                                          ");
            strSQL.Append(" ) b                                              ");
            strSQL.Append(" on a.ID=b.ID                                                                          ");
            strSQL.Append(" where ifnull(XDLOTNO,'')<>'' and  ifnull(a.CKWCQF,'0')<>'1'                            ");
            strSQL.Append(" and b.CKZLBH='" + CKZLBH + "'                                                                     ");
            if (!string.IsNullOrEmpty(strX))
                strSQL.Append(" and ifnull(XLOTNO,'') not in (" + strX + ")                                            ");
            if (!string.IsNullOrEmpty(strDD))
                strSQL.Append(" and ifnull(DDLOTNO,'') not in (" + strDD + ")                                          ");
            strSQL.Append(" order by b.LHRQ,a.XDINTZF                                                                       ");
            strSQL.Append(" limit " + XDnum + "                                                                               ");
            dtXD = DbHelperMySql.Query(strSQL.ToString()).Tables[0];
            if (dtDD.Rows.Count > 0)
                dtXD.Merge(dtDD);
            if (dtX.Rows.Count > 0)
                dtXD.Merge(dtX);
            dtResult = dtXD;
            return dtResult;
        }

        /// <summary>
        /// 得到最大的追番+1
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetMaxZF(Model.ffd050 model)
        {
            string strSql = "select max(ZF) as ZF from FFD050 where CKZLRQ='" + model.CKZLRQ + "' and CLBH='" + model.CLBH + "' and PM='" + model.PM + "' and PH='" + model.PH + "';";
            object obj = DbHelperMySql.GetSingle(strSql);

            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 1;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString()) + 1;
            }

            return cmdresult.ToString().PadLeft(2, '0');

        }
        /// <summary>
        /// 删除当次出库的数据
        /// </summary>
        /// <param name="CKZLBH"></param>
        /// <returns></returns>
        public bool deleteWLCK(string CKZLBH)
        {
            bool bResult = false;
            List<string> listStrSQL = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update                                                                                ");
            strSql.Append(" ffd070 a                                                                              ");
            strSql.Append(" left join ffd020 b                                                                    ");
            strSql.Append(" on a.LOTNO=if(a.TXMQF='1',b.XDLOTNO,if(a.TXMQF='2',b.DDLOTNO,b.XLOTNO))               ");
            strSql.Append(" set b.CKWCQF='0',                                                                     ");
            strSql.Append(" b.CKRBH='',                                                                           ");
            strSql.Append(" b.CKRQ='',                                                                             ");
            strSql.Append(" b.CKZLBH=NULL                                                                             ");
            strSql.Append(" where a.CKZLBH='" + CKZLBH + "';                                            ");
            listStrSQL.Add(strSql.ToString());
            strSql = new StringBuilder();
            strSql.Append(" delete from ffd070 where CKZLBH='" + CKZLBH + "';                           ");
            listStrSQL.Add(strSql.ToString());
            int iRet = DbHelperMySql.ExecuteSqlTran(listStrSQL);
            bResult = iRet == -1 ? false : true;
            return bResult;
        }

        /// <summary>
        /// 获得出库指令明细
        /// </summary>
        public DataSet GetCKZLMX(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CKZLBH,CKRQ,CLBH,PM,PH,KHBH,ZF,DJ,ZSSLHJ,ZSXS,ZSDDS,ZSXDS,CKZLXDZ,CKDDZ,CKWCS,WCQF,BZ,DMQF,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM,CKZLRQ ");
            strSql.Append(" FROM ffd050 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CKRQ desc,PM,PH,CLBH");
            return DbHelperMySql.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得出库指令明细
        /// </summary>
        public DataSet GetCKZLMXEXCEL(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select CKZLBH,CKZLRQ,b.KHMC,PM,PH,CLBH,ZSSLHJ,DJ,ZSSLHJ*DJ,");
            strSql.Append(" case when WCQF = '0' then '未出库' when  WCQF = '1' then '已出库' end WCQF ");
            strSql.Append(" FROM ffd050 a  left join fmd030 b on b.khbh = a.khbh ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CKRQ desc,PM,PH,CLBH");

            return DbHelperMySql.Query(strSql.ToString());
        }


        public DataSet GetdtForCry(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select CKZLBH,a.PM AS PM,a.PH AS PH, a.CLBH AS CLBH,ZSSLHJ,DW ,DJ,BZ");
            strSql.Append(" FROM ffd050 a  left join fmd030 b on b.khbh = a.khbh ");
            strSql.Append(" LEFT JOIN (  ");
            strSql.Append(" select PM,PH,CLBH,b.ZSMC as DW from fmd060 a LEFT JOIN fmd000 b ON (a.JLDW=b.MCKEY) WHERE b.GLBH='06' ) c ON (a.PM=c.PM and a.PH=c.PH AND a.CLBH=c.CLBH)  ");
 
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by a.PM,a.PH,a.CLBH");

            return DbHelperMySql.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得成品出库明细
        /// </summary>
        public DataSet GetCPCKMX(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CKZLBH,CKRQ,CLBH,PM,PH,KHBH,ZF,DJ,ZSSLHJ,ZSXS,ZSDDS,ZSXDS,CKZLXDZ,CKDDZ,CKWCS,WCQF,BZ,DMQF,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM,CKZLRQ ");
            strSql.Append(" FROM ffd050 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySql.Query(strSql.ToString());
        }

        #endregion  MethodEx

        /// <summary>
        /// PC25 检索01
        /// </summary>
        public DataTable GetPc25Js01(string strStartRq, string strEndRq, string strKhbh)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("  select b.KHMC KHMC,a.KHBH KHBH,a.CKRQ CKRQ,a.CLBH CLBH,a.PM PM,a.PH PH,SUM(a.CKWCS) CKSL, ");
            strSql.Append(" a.CKZLBH CKZLBH from ffd050 a ");
            strSql.Append(" left join fmd030 b on a.KHBH = b.KHBH ");
            strSql.Append(" where a.WCQF = '1'  ");
            strSql.Append(" and a.CKRQ between '" + strStartRq + "' and '" + strEndRq + "'  ");

            if (!string.IsNullOrEmpty(strKhbh))
            {
                strSql.Append(" and a.KHBH = '" + strKhbh + "' ");
            }

            strSql.Append(" group by a.KHBH,a.CKRQ,a.CLBH,a.PM,a.PH ");
            return DbHelperMySql.Query(strSql.ToString()).Tables[0];

        }




    }
}

