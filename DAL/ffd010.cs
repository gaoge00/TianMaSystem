/**  版本信息模板在安装目录下，可自行修改。
* ffd010.cs
*
* 功 能： N/A
* 类 名： ffd010
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:46   N/A    初版
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
    /// 数据访问类:ffd010
    /// </summary>
    public partial class ffd010
    {
        public ffd010()
        { }
        #region  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string HLPCLOTNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ffd010");
            strSql.Append(" where HLPCLOTNO='" + HLPCLOTNO + "' ");
            return DbHelperMySql.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.ffd010 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

            if (model.LHRQ != null)
            {
                strSql1.Append("LHRQ,");
                strSql2.Append("'" + model.LHRQ + "',");
            }
            if (model.HLPCLOTNO != null)
            {
                strSql1.Append("HLPCLOTNO,");
                strSql2.Append("'" + model.HLPCLOTNO + "',");
            }
            if (model.JPRQ != null)
            {
                strSql1.Append("JPRQ,");
                strSql2.Append("'" + model.JPRQ + "',");
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
            if (model.HGSL != null)
            {
                strSql1.Append("HGSL,");
                strSql2.Append("" + model.HGSL + ",");
            }
            if (model.BLSL != null)
            {
                strSql1.Append("BLSL,");
                strSql2.Append("" + model.BLSL + ",");
            }
            if (model.XDSLBZ != null)
            {
                strSql1.Append("XDSLBZ,");
                strSql2.Append("" + model.XDSLBZ + ",");
            }
            if (model.YRKID != null)
            {
                strSql1.Append("YRKID,");
                strSql2.Append("" + model.YRKID + ",");
            }
            if (model.RKZF != null)
            {
                strSql1.Append("RKZF,");
                strSql2.Append("'" + model.RKZF + "',");
            }
            if (model.YLHR != null)
            {
                strSql1.Append("YLHR,");
                strSql2.Append("'" + model.YLHR + "',");
            }
            if (model.LHBGZNO != null)
            {
                strSql1.Append("LHBGZNO,");
                strSql2.Append("'" + model.LHBGZNO + "',");
            }
            if (model.LHBGRQ != null)
            {
                strSql1.Append("LHBGRQ,");
                strSql2.Append("'" + model.LHBGRQ + "',");
            }
            if (model.DMQF != null)
            {
                strSql1.Append("DMQF,");
                strSql2.Append("'" + model.DMQF + "',");
            }

            if (model.MAXXDZF != null)
            {
                strSql1.Append("MAXXDZF,");
                strSql2.Append("" + model.MAXXDZF + ",");
            }
            if (model.MAXDDZF != null)
            {
                strSql1.Append("MAXDDZF,");
                strSql2.Append("" + model.MAXDDZF + ",");
            }
            if (model.MAXXZF != null)
            {
                strSql1.Append("MAXXZF,");
                strSql2.Append("" + model.MAXXZF + ",");
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
            strSql.Append("insert into ffd010(");
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
        public bool Update(Model.ffd010 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ffd010 set ");

            if (model.LHRQ != null)
            {
                strSql.Append("LHRQ='" + model.LHRQ + "',");
            }
            else
            {
                strSql.Append("LHRQ= null ,");
            }
            if (model.HLPCLOTNO != null)
            {
                strSql.Append("HLPCLOTNO='" + model.HLPCLOTNO + "',");
            }
            else
            {
                strSql.Append("HLPCLOTNO= null ,");
            }
            if (model.JPRQ != null)
            {
                strSql.Append("JPRQ='" + model.JPRQ + "',");
            }
            else
            {
                strSql.Append("JPRQ= null ,");
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
            if (model.HGSL != null)
            {
                strSql.Append("HGSL=" + model.HGSL + ",");
            }
            else
            {
                strSql.Append("HGSL= null ,");
            }
            if (model.BLSL != null)
            {
                strSql.Append("BLSL=" + model.BLSL + ",");
            }
            else
            {
                strSql.Append("BLSL= null ,");
            }
            if (model.XDSLBZ != null)
            {
                strSql.Append("XDSLBZ=" + model.XDSLBZ + ",");
            }
            else
            {
                strSql.Append("XDSLBZ= null ,");
            }
            if (model.YRKID != null)
            {
                strSql.Append("YRKID=" + model.YRKID + ",");
            }
            else
            {
                strSql.Append("YRKID= null ,");
            }
            if (model.RKZF != null)
            {
                strSql.Append("RKZF='" + model.RKZF + "',");
            }
            else
            {
                strSql.Append("RKZF= null ,");
            }
            if (model.YLHR != null)
            {
                strSql.Append("YLHR='" + model.YLHR + "',");
            }
            else
            {
                strSql.Append("YLHR= null ,");
            }
            if (model.LHBGZNO != null)
            {
                strSql.Append("LHBGZNO='" + model.LHBGZNO + "',");
            }
            else
            {
                strSql.Append("LHBGZNO= null ,");
            }
            if (model.LHBGRQ != null)
            {
                strSql.Append("LHBGRQ='" + model.LHBGRQ + "',");
            }
            else
            {
                strSql.Append("LHBGRQ= null ,");
            }
            if (model.DMQF != null)
            {
                strSql.Append("DMQF='" + model.DMQF + "',");
            }
            else
            {
                strSql.Append("DMQF= null ,");
            }


            if (model.MAXXDZF != null)
            {
                strSql.Append("MAXXDZF=" + model.MAXXDZF + ",");
            }
            else
            {
                strSql.Append("MAXXDZF= null ,");
            }
            if (model.MAXDDZF != null)
            {
                strSql.Append("MAXDDZF=" + model.MAXDDZF + ",");
            }
            else
            {
                strSql.Append("MAXDDZF= null ,");
            }
            if (model.MAXXZF != null)
            {
                strSql.Append("MAXXZF=" + model.MAXXZF + ",");
            }
            else
            {
                strSql.Append("MAXXZF= null ,");
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
            strSql.Append(" where ID=" + model.ID + "");
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
        public bool Delete(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ffd010 ");
            strSql.Append(" where ID=" + ID + "");
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ffd010 ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public Model.ffd010 GetModel(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" ID,RKQF,LHRQ,HLPCLOTNO,JPRQ,CLBH,PM,PH,HGSL,BLSL,XDSLBZ,YRKID,RKZF,YLHR,LHBGZNO,LHBGRQ,DMQF,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
            strSql.Append(" from ffd010 ");
            strSql.Append(" where ID=" + ID + "");
            Model.ffd010 model = new Model.ffd010();
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
        public Model.ffd010 DataRowToModel(DataRow row)
        {
            Model.ffd010 model = new Model.ffd010();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["LHRQ"] != null)
                {
                    model.LHRQ = row["LHRQ"].ToString();
                }
                if (row["HLPCLOTNO"] != null)
                {
                    model.HLPCLOTNO = row["HLPCLOTNO"].ToString();
                }
                if (row["JPRQ"] != null)
                {
                    model.JPRQ = row["JPRQ"].ToString();
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
                if (row["HGSL"] != null && row["HGSL"].ToString() != "")
                {
                    model.HGSL = int.Parse(row["HGSL"].ToString());
                }
                if (row["BLSL"] != null && row["BLSL"].ToString() != "")
                {
                    model.BLSL = int.Parse(row["BLSL"].ToString());
                }
                if (row["XDSLBZ"] != null && row["XDSLBZ"].ToString() != "")
                {
                    model.XDSLBZ = int.Parse(row["XDSLBZ"].ToString());
                }
                if (row["YRKID"] != null && row["YRKID"].ToString() != "")
                {
                    model.YRKID = int.Parse(row["YRKID"].ToString());
                }
                if (row["RKZF"] != null)
                {
                    model.RKZF = row["RKZF"].ToString();
                }
                if (row["YLHR"] != null)
                {
                    model.YLHR = row["YLHR"].ToString();
                }
                if (row["LHBGZNO"] != null)
                {
                    model.LHBGZNO = row["LHBGZNO"].ToString();
                }
                if (row["LHBGRQ"] != null)
                {
                    model.LHBGRQ = row["LHBGRQ"].ToString();
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
            strSql.Append("select ID,RKQF,LHRQ,HLPCLOTNO,JPRQ,CLBH,PM,PH,HGSL,BLSL,XDSLBZ,YRKID,RKZF,YLHR,LHBGZNO,LHBGRQ,DMQF,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
            strSql.Append(" FROM ffd010 ");
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
            strSql.Append("select count(1) FROM ffd010 ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from ffd010 T ");
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
        /// 根据混炼LotNo取入库追番		
        /// </summary>		
        /// <param name="strHLPCLOTNO"></param>		
        /// <returns></returns>		
        public DataTable getRKZF(string strHLPCLOTNO)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select RKZF as ZSMC,ID as MCKEY from FFD010  ");
            strSQL.Append("where HLPCLOTNO='" + strHLPCLOTNO + "'  ");
            strSQL.Append("order by RKZF  ");
            DataTable dtResult = DbHelperMySql.Query(strSQL.ToString()).Tables[0];
            return dtResult;
        }

        /// <summary>		
        /// 根据混炼LotNo取入库追番		
        /// </summary>		
        /// <param name="strHLPCLOTNO"></param>		
        /// <returns></returns>		
        public DataTable getRKMaxZF(string LHRQ)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(" select distinct MAXXDZF,MAXDDZF,MAXXZF from FFD011 ");
            strSQL.Append(" where LHRQ='" + LHRQ + "'  ");
            //return strSQL.ToString();
            DataTable dtResult = DbHelperMySql.Query(strSQL.ToString()).Tables[0];
            //DataTable dtResult = new DataTable();
            return dtResult;
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string AddStrSQL(Model.ffd010 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ID != 0 || model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }

            if (model.LHRQ != null)
            {
                strSql1.Append("LHRQ,");
                strSql2.Append("'" + model.LHRQ + "',");
            }
            if (model.HLPCLOTNO != null)
            {
                strSql1.Append("HLPCLOTNO,");
                strSql2.Append("'" + model.HLPCLOTNO + "',");
            }
            if (model.JPRQ != null)
            {
                strSql1.Append("JPRQ,");
                strSql2.Append("'" + model.JPRQ + "',");
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
            if (model.HGSL != null)
            {
                strSql1.Append("HGSL,");
                strSql2.Append("" + model.HGSL + ",");
            }
            if (model.BLSL != null)
            {
                strSql1.Append("BLSL,");
                strSql2.Append("" + model.BLSL + ",");
            }
            if (model.XDSLBZ != null)
            {
                strSql1.Append("XDSLBZ,");
                strSql2.Append("" + model.XDSLBZ + ",");
            }
            if (model.YRKID != null)
            {
                strSql1.Append("YRKID,");
                strSql2.Append("" + model.YRKID + ",");
            }
            if (model.RKZF != null)
            {
                strSql1.Append("RKZF,");
                strSql2.Append("'" + model.RKZF + "',");
            }
            if (model.YLHR != null)
            {
                strSql1.Append("YLHR,");
                strSql2.Append("'" + model.YLHR + "',");
            }
            if (model.LHBGZNO != null)
            {
                strSql1.Append("LHBGZNO,");
                strSql2.Append("'" + model.LHBGZNO + "',");
            }
            if (model.LHBGRQ != null)
            {
                strSql1.Append("LHBGRQ,");
                strSql2.Append("'" + model.LHBGRQ + "',");
            }
            if (model.DMQF != null)
            {
                strSql1.Append("DMQF,");
                strSql2.Append("'" + model.DMQF + "',");
            }




            if (model.MAXXDZF != null)
            {
                strSql1.Append("MAXXDZF,");
                strSql2.Append("" + model.MAXXDZF + ",");
            }
            if (model.MAXDDZF != null)
            {
                strSql1.Append("MAXDDZF,");
                strSql2.Append("" + model.MAXDDZF + ",");
            }
            if (model.MAXXZF != null)
            {
                strSql1.Append("MAXXZF,");
                strSql2.Append("" + model.MAXXZF + ",");
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
            strSql.Append("insert into ffd010(");
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
        public string UpdateStrSQL(Model.ffd010 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ffd010 set ");

            if (model.LHRQ != null)
            {
                strSql.Append("LHRQ='" + model.LHRQ + "',");
            }
            else
            {
                strSql.Append("LHRQ= null ,");
            }
            if (model.HLPCLOTNO != null)
            {
                strSql.Append("HLPCLOTNO='" + model.HLPCLOTNO + "',");
            }
            else
            {
                strSql.Append("HLPCLOTNO= null ,");
            }
            if (model.JPRQ != null)
            {
                strSql.Append("JPRQ='" + model.JPRQ + "',");
            }
            else
            {
                strSql.Append("JPRQ= null ,");
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

            if (model.MAXXDZF != null)
            {
                strSql.Append("MAXXDZF=" + model.MAXXDZF + ",");
            }
            else
            {
                strSql.Append("MAXXDZF= MAXXDZF ,");
            }
            if (model.MAXDDZF != null)
            {
                strSql.Append("MAXDDZF=" + model.MAXDDZF + ",");
            }
            else
            {
                strSql.Append("MAXDDZF= MAXDDZF ,");
            }
            if (model.MAXXZF != null)
            {
                strSql.Append("MAXXZF=" + model.MAXXZF + ",");
            }
            else
            {
                strSql.Append("MAXXZF= MAXXZF ,");
            }


            if (model.HGSL != null)
            {
                strSql.Append("HGSL=" + model.HGSL + ",");
            }
            else
            {
                strSql.Append("HGSL= null ,");
            }
            if (model.BLSL != null)
            {
                strSql.Append("BLSL=" + model.BLSL + ",");
            }
            else
            {
                strSql.Append("BLSL= null ,");
            }
            if (model.XDSLBZ != null)
            {
                strSql.Append("XDSLBZ=" + model.XDSLBZ + ",");
            }
            else
            {
                strSql.Append("XDSLBZ= null ,");
            }
            if (model.YRKID != null)
            {
                strSql.Append("YRKID=" + model.YRKID + ",");
            }
            else
            {
                strSql.Append("YRKID= null ,");
            }
            if (model.RKZF != null)
            {
                strSql.Append("RKZF='" + model.RKZF + "',");
            }
            else
            {
                strSql.Append("RKZF= null ,");
            }
            if (model.YLHR != null)
            {
                strSql.Append("YLHR='" + model.YLHR + "',");
            }
            else
            {
                strSql.Append("YLHR= null ,");
            }
            if (model.LHBGZNO != null)
            {
                strSql.Append("LHBGZNO='" + model.LHBGZNO + "',");
            }
            else
            {
                strSql.Append("LHBGZNO= null ,");
            }
            if (model.LHBGRQ != null)
            {
                strSql.Append("LHBGRQ='" + model.LHBGRQ + "',");
            }
            else
            {
                strSql.Append("LHBGRQ= null ,");
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
                strSql.Append("GXZBH='" + model.RLZBH + "',");
            }
            else
            {
                strSql.Append("GXZBH= null ,");
            }
            if (model.RLR != null)
            {
                strSql.Append("GXR='" + model.RLR + "',");
            }
            else
            {
                strSql.Append("GXR= null ,");
            }
            if (model.RLSJ != null)
            {
                strSql.Append("GXSJ='" + model.RLSJ + "',");
            }
            else
            {
                strSql.Append("GXSJ= null ,");
            }
            if (model.RLDMM != null)
            {
                strSql.Append("GXDMM='" + model.RLDMM + "',");
            }
            else
            {
                strSql.Append("GXDMM= null ,");
            }

            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where ID=" + model.ID + "");
            return strSql.ToString();
        }

        /// <summary>
        /// 获取已经存在的检品信息
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public DataSet getJPInfo(string ID,string RKQF)
        {
            StringBuilder strSQL = new StringBuilder();
            //strSQL.Append("select PM,PH,JPRQ,HGSL,BLSL,XDSLBZ,IF(ifnull(c.SYMC,'')='',b.SYMC,c.SYMC) JPR from ffd010 a  ");
            //strSQL.Append("left join (select SYBH,SYMC from fmd010) b  ");
            //strSQL.Append("on a.RLZBH=b.SYBH  ");
            //strSQL.Append("left join (select SYBH,SYMC from fmd010) c  ");
            //strSQL.Append("on a.GXZBH=c.SYBH  ");
            //strSQL.Append("where ID=" + ID + ";  ");
            strSQL.Append("select PM,PH,JPRQ,HGSL,BLSL,XDSLBZ,b.JPRBH,c.SYMC JPR,b.LHR,b.MJBH from ffd010 a   ");
            //增加 XDLOTNO=SSXDLOTNO 是为了去除掉拼袋的数据，因为拼袋的硫化人可能不是同一人
            strSQL.Append("left join (select distinct ID,JPRBH,RKQF,LHR,MJBH from ffd020 where RKQF='" + RKQF + "' and XDLOTNO=SSXDLOTNO) b  ");
            strSQL.Append("on a.ID=b.ID    ");
            strSQL.Append("left join (select SYBH,SYMC from fmd010) c    ");
            strSQL.Append("on b.JPRBH=c.SYBH    ");
            strSQL.Append("where a.ID=" + ID + ";  ");
   

            strSQL.Append("select XDLOTNO from ffd020  ");
            strSQL.Append("where ID=" + ID + "  ");
            strSQL.Append("and RKQF='" + RKQF + "'  order by XDINTZF ;  ");


            return DbHelperMySql.Query(strSQL.ToString());

        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string DeleteFFD010Str(long ID)
        {
            StringBuilder strSql = new StringBuilder();

            //strSql.Append("delete from ffd010  where ID in ( ");
            //strSql.Append("select distinct b.ID from ffd020 a ");
            //strSql.Append("left join ffd020 b ");
            //strSql.Append("on a.XDLOTNO=b.SSXDLOTNO ");
            //strSql.Append("where a.ID=" + ID + " ");
            //strSql.Append(") ");

            strSql.Append("delete from ffd010 ");
            strSql.Append(" where id=" + ID + " ; ");
            return strSql.ToString();
        }

        /// <summary>
        ///  更新小袋，大袋，箱的最大追番号
        /// </summary>
        /// <param name="HLPCLOTNO">混炼批次条形码</param>
        /// <param name="MaxXDZF">最大小袋追番</param>
        /// <param name="MaxDDZF">最大大袋追番</param>
        /// <param name="MaxXZF">最大箱追番</param>
        /// <returns></returns>
        public string UpdateFFD010ThreeZFStr(string LHRQ, int? MaxXDZF, int? MaxDDZF, int? MaxXZF)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append(" update ffd011 ");
            //strSql.Append(" set LHRQ=LHRQ ");
            //if (MaxXDZF != 0 && MaxXDZF != null)
            //{
            //    strSql.Append(" ,MAXXDZF=" + MaxXDZF + "   ");
            //}
            //if (MaxDDZF != 0 && MaxDDZF != null)
            //{
            //    strSql.Append(" ,MAXDDZF=" + MaxDDZF + "   ");
            //}
            //if (MaxXZF != 0 && MaxXZF != null)
            //{
            //    strSql.Append(" ,MAXXZF=" + MaxXZF + "   ");
            //}

            //strSql.Append(" where LHRQ='" + LHRQ + "';");

            strSql.Append(" INSERT INTO ffd011(                                                                   ");
            strSql.Append(" LHRQ                                                                     ");
            if (MaxXDZF != 0 && MaxXDZF != null)
                strSql.Append(" , MAXXDZF ");
            if (MaxDDZF != 0 && MaxDDZF != null)
                strSql.Append(" ,MAXDDZF ");
            if (MaxXZF != 0 && MaxXZF != null)
                strSql.Append(" ,MAXXZF                                                                            ");                      
            strSql.Append(" )                                                                                     ");
            strSql.Append(" SELECT * FROM (                                                                       ");
            strSql.Append(" SELECT                                                                                ");
            strSql.Append(" DISTINCT '" + LHRQ + "' LHRQ                                                         ");
            if (MaxXDZF != 0 && MaxXDZF != null)
                strSql.Append(" ," + (MaxXDZF ?? 0) + " AS MAXXDZF ");
            if (MaxDDZF != 0 && MaxDDZF != null)
                strSql.Append(" ," + (MaxDDZF ?? 0) + " AS MAXDDZF ");
            if (MaxXZF != 0 && MaxXZF != null)
                strSql.Append(" ," + (MaxXZF ?? 0) + " AS MAXXZF ");
            strSql.Append(" )B                                                                                    ");
            strSql.Append(" ON DUPLICATE KEY                                                                      ");
            strSql.Append(" UPDATE                                                                                ");
            strSql.Append(" LHRQ=B.LHRQ                                                                          ");
            if (MaxXDZF != 0 && MaxXDZF != null)
                strSql.Append(" ,MAXXDZF=B.MAXXDZF                                                                    ");
            if (MaxDDZF != 0 && MaxDDZF != null)
                strSql.Append(" ,MAXDDZF=B.MAXDDZF                                                                    ");
            if (MaxXZF != 0 && MaxXZF != null)
                strSql.Append(" ,MAXXZF=B.MAXXZF                                                                      ");

            return strSql.ToString();
        }



        public string UpdateLHR_SQL(string oldHLPCLOTNO, string newHLPCLOTNO, string newLHRQ, string userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update FFD010 set HLPCLOTNO='" + newHLPCLOTNO + "',LHRQ = '" + newLHRQ + "',LHBGZNO='" + userID + "'");
            strSql.Append(" Where HLPCLOTNO = '" + oldHLPCLOTNO + "'");
            return strSql.ToString();
        }

        #endregion  MethodEx


        public DataTable GetPc21Js(DateTime startDt,DateTime endDt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select   ");
            strSql.Append("  a.PH PH,a.CLBH CLBH,  ");
            strSql.Append("  SUM(ifnull(a.HGSL,0)) + SUM(ifnull(a.BLSL,0))  ZSCSL,  ");
            strSql.Append("  SUM(ifnull(a.HGSL,0)) HGSL,  ");
            strSql.Append("   SUM(ifnull(a.BLSL,0)) BLSL,  ");
            strSql.Append("  ROUND(SUM(ifnull(a.HGSL,0)) / (SUM(ifnull(a.HGSL,0)) + SUM(ifnull(a.BLSL,0))) * 100,2) HGL,  ");
            strSql.Append("  c.ZSMC FLH  ");
            strSql.Append("  from ffd010 a  ");
            strSql.Append("  left join fmd060 b on a.PH= b.PH and a.CLBH = b.CLBH  ");
            strSql.Append("  left join fmd000 c on c.glbh = '05' and b.flh = c.mckey  ");
            strSql.Append("  where 1=1   ");
            strSql.Append(" and a.LHRQ between  '" + startDt.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "' and '" + endDt.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "' ");

            //if (!string.IsNullOrEmpty(strLhrq))
            //{
            //   //strSql.Append(" and substring(a.LHRQ,1,7) = '" + strLhrq + "'  ");
            //}

            strSql.Append("  group by a.PH,a.CLBH,c.ZSMC  ");
            strSql.Append("  order by a.PH,a.CLBH  ");

            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }

        public DataTable GetPc25Js02(string strCkrq, string strkhbh, string strClbh, string strPm, string strPh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select HLPCLOTNO from ffd010 where ID in(  ");
            strSql.Append("  select distinct ID from ffd020 where ckzlbh in   ");
            strSql.Append("  (  ");
            strSql.Append("  select a.CKZLBH CKZLBH from ffd050 a  ");
            strSql.Append("  where a.WCQF = '1'   ");
            strSql.Append("  and a.CKRQ = '" + strCkrq + "'   ");
            strSql.Append("  and a.KHBH = '" + strkhbh + "'  ");
            strSql.Append("  and a.CLBH = '" + strClbh + "'  ");
            strSql.Append("  and a.PM = '" + strPm + "'  ");
            strSql.Append("  and a.PH = '" + strPh + "'  ");
            strSql.Append("  group by a.CLBH,a.PM,a.PH,a.CKZLBH  ");
            strSql.Append("  )  ");
            strSql.Append("  )  ");

            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 得到合格证明细(BSR)
        /// </summary>
        /// <param name="qrCode">条形码</param>
        /// <param name="checkDt">检品日期</param>
        /// <param name="checkUser">检品人</param>
        /// <returns></returns>
        public DataTable GetHgzBsrMX(string qrCode, string strKHBH)
        {
            DataTable mydt = new DataTable();
            StringBuilder strSql = new StringBuilder();

                strSql.Append("SELECT  ");
                strSql.Append("case  ");
                strSql.Append("	when ifnull(z.PHKH,'')!='' then z.PHKH ");
                strSql.Append("	else c.PH ");
                strSql.Append("end as '品号', ");
                strSql.Append("case  ");
                strSql.Append("	when ifnull(z.PMKH,'')!='' then z.PMKH ");
                strSql.Append("	else c.PM ");
                strSql.Append("end as '品名', ");
                strSql.Append("substring_index(substring_index(a.SSXDLOTNO,',',1),'_',-2)  as 'LOTNo.',  ");
                strSql.Append("CONCAT(cast(sum(a.SL) as SIGNED),'个') as '数量' ,   ");

                strSql.Append("case  ");
                strSql.Append("	when ifnull(z.CLBHKH,'')!='' then z.CLBHKH ");
                strSql.Append("	else c.CLBH ");
                strSql.Append("end as '材质', ");
                //strSql.Append("c.CLBH as '材质',  ");

                strSql.Append("DATE_FORMAT(c.JPRQ,'%Y年%m月%d日') as '检查日',a.JPRBH as '检品人'  ");
                strSql.Append("FROM `ffd020` a   ");
                strSql.Append("left join `ffd010` c ON(a.id=c.id)   ");
                strSql.Append("left join `fmd100` z ON(KHBH='" + strKHBH + "' and (c.PM = z.PMGC and c.PH = z.PHGC  and c.CLBH = z.CLBHGC))   ");
                strSql.Append("where a.SSXDLOTNO='" + qrCode + "'  ");


            //strSql.Append("SELECT c.PH as '品号',c.PM as '品名', ");
            //strSql.Append("substring_index(substring_index(a.SSXDLOTNO,',',1),'_',-2)  as 'LOTNo.', ");
            //strSql.Append("CONCAT(cast(a.SL as SIGNED),'个') as '数量' ,c.CLBH as '材质',   ");
            //strSql.Append("DATE_FORMAT(c.JPRQ,'%Y年%m月%d日') as '检查日',a.JPRBH as '检品人' FROM `ffd020` a  ");
            //strSql.Append("left join `ffd010` c ON(a.id=c.id)  ");
            //strSql.Append("where a.SSXDLOTNO='" + qrCode + "'  ");

            //strSql.Append("SELECT c.PH as '品号',c.PM as '品名',a.SSXDLOTNO as 'LOTNo.',CONCAT(((b.SL) as SIGNED),'个') as '数量' ,c.CLBH as '材质',  ");
            //strSql.Append("DATE_FORMAT(c.JPRQ,'%Y年%m月%d日') as '检查日',d.SYMC as '检品人' ");
            //strSql.Append("FROM `ffd020` a ");
            //strSql.Append("LEFT JOIN `ffd020` b ON(a.id=b.id) ");
            //strSql.Append("left join `ffd010` c ON(a.id=c.id) ");
            //strSql.Append("left join `fmd010` d ON(a.JPRBH=d.SYBH) ");
            //strSql.Append("where a.SSXDLOTNO='" + qrCode + "' ");

            mydt = DbHelperMySql.Query(strSql.ToString()).Tables[0];
            return mydt;

        }

        /// <summary>
        /// 得到合格证明细(ROHS)
        /// </summary>
        /// <param name="qrCode">条形码</param>
        /// <param name="strBZ">备注</param>
        /// <returns></returns>
        public DataTable GetHgzRohsMX(string qrCode, string strBZ, string strKHBH)
        {

            DataTable mydt = new DataTable();
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT  ");
            strSql.Append("case  ");
            strSql.Append("	when ifnull(z.PHKH,'')!='' then z.PHKH ");
            strSql.Append("	else c.PH ");
            strSql.Append("end as '类型', ");
            strSql.Append("case  ");
            strSql.Append("	when ifnull(z.PMKH,'')!='' then z.PMKH ");
            strSql.Append("	else c.PM ");
            strSql.Append("end as '品名', ");
            strSql.Append("CONCAT(cast(sum(a.SL) as SIGNED),'') as '数量'  ");
            strSql.Append(",  DATE_FORMAT(c.LHRQ,'%Y-%m-%d') as '生产日期','" + strBZ + "' as '备注' ");
            strSql.Append("FROM `ffd020` a  ");
            strSql.Append("left join `ffd010` c ON(a.id=c.id) ");
            strSql.Append("left join `fmd100` z ON(KHBH='" + strKHBH + "' and (c.PM = z.PMGC   and c.PH = z.PHGC  and c.CLBH = z.CLBHGC))   ");
            strSql.Append("where a.SSXDLOTNO='" + qrCode + "' ");


            //strSql.Append("SELECT c.PM as '品名',c.PH as '类型',CONCAT(cast((b.SL) as SIGNED),'') as '数量'  ");
            //strSql.Append(",  DATE_FORMAT(c.LHRQ,'%Y-%m-%d') as '生产日期','" + strBZ + "' as '备注' ");
            //strSql.Append("FROM `ffd020` a  ");
            //strSql.Append("LEFT JOIN `ffd020` b ON(a.id=b.id) ");
            //strSql.Append("left join `ffd010` c ON(a.id=c.id) ");
            //strSql.Append("where a.SSXDLOTNO='" + qrCode + "' ");

            //strSql.Append("SELECT c.PM as '品名',c.PH as '类型',CONCAT(cast((b.SL) as SIGNED),'') as '数量'  ");
            //strSql.Append(",  DATE_FORMAT(c.LHRQ,'%Y-%m-%d') as '生产日期','" + strBZ + "' as '备注' ");
            //strSql.Append("FROM `ffd020` a LEFT JOIN `ffd020` b ON(a.id=b.id) left join `ffd010` c ON(a.id=c.id)  ");
            //strSql.Append("left join `fmd010` d ON(a.JPRBH=d.SYBH) ");
            //strSql.Append("where a.SSXDLOTNO='" + qrCode + "' ");

            mydt = DbHelperMySql.Query(strSql.ToString()).Tables[0];
            return mydt;

        }


    }
}

