using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;

namespace DAL
{
    public class fmd100
    {
        #region  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KHBH, string PMGC, string PHGC, string CLBHGC)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from fmd100");
            strSql.Append(" where KHBH='" + KHBH + "' and PMGC='" + PMGC + "' and PHGC='" + PHGC + "' and CLBHGC = '" + CLBHGC + "' ");
            return DbHelperMySql.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.fmd100 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.KHBH != null)
            {
                strSql1.Append("KHBH,");
                strSql2.Append("'" + model.KHBH + "',");
            }
            if (model.PMGC != null)
            {
                strSql1.Append("PMGC,");
                strSql2.Append("'" + model.PMGC + "',");
            }
            if (model.PHGC != null)
            {
                strSql1.Append("PHGC,");
                strSql2.Append("'" + model.PHGC + "',");
            }
            if (model.PMKH != null)
            {
                strSql1.Append("PMKH,");
                strSql2.Append("'" + model.PMKH + "',");
            }
            if (model.PHKH != null)
            {
                strSql1.Append("PHKH,");
                strSql2.Append("'" + model.PHKH + "',");
            }

            if (model.CLBHGC != null)
            {
                strSql1.Append("CLBHGC,");
                strSql2.Append("'" + model.CLBHGC + "',");
            }
            if (model.CLBHKH != null)
            {
                strSql1.Append("CLBHKH,");
                strSql2.Append("'" + model.CLBHKH + "',");
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
            strSql.Append("insert into fmd100(");
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
        public string Update(Model.fmd100 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update fmd100 set ");
            if (model.PMKH != null)
            {
                strSql.Append("PMKH='" + model.PMKH + "',");
            }
            else
            {
                strSql.Append("PMKH= null ,");
            }

            if (model.PHKH != null)
            {
                strSql.Append("PHKH='" + model.PHKH + "',");
            }
            else
            {
                strSql.Append("PHKH= null ,");
            }

            if (model.CLBHKH != null)
            {
                strSql.Append("CLBHKH='" + model.CLBHKH + "',");
            }
            else
            {
                strSql.Append("CLBHKH= null ,");
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
            strSql.Append(" where KHBH='" + model.KHBH + "' and PMGC='" + model.PMGC + "' and PHGC='" + model.PHGC + "' ");
            return strSql.ToString();
       
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string KHBH, string PMGC, string PHGC, string CLBHGC)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fmd100 ");
            strSql.Append(" where KHBH='" + KHBH + "' and PMGC='" + PMGC + "' and PHGC='" + PHGC + "' and CLBHGC = '" + CLBHGC + "' ");
            return strSql.ToString();
        
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.fmd100 GetModel(string KHBH, string PMGC, string PHGC)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" KHBH,PMGC,PHGC,PMKH,PHKH,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
            strSql.Append(" from fmd100 ");
            strSql.Append(" where KHBH='" + KHBH + "' and PMGC='" + PMGC + "' and PHGC='" + PHGC + "' ");
            Model.fmd100 model = new Model.fmd100();
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
        public Model.fmd100 DataRowToModel(DataRow row)
        {
            Model.fmd100 model = new Model.fmd100();
            if (row != null)
            {
                if (row["KHBH"] != null)
                {
                    model.KHBH = row["KHBH"].ToString();
                }
                if (row["PMGC"] != null)
                {
                    model.PMGC = row["PMGC"].ToString();
                }
                if (row["PHGC"] != null)
                {
                    model.PHGC = row["PHGC"].ToString();
                }
                if (row["PMKH"] != null)
                {
                    model.PMKH = row["PMKH"].ToString();
                }
                if (row["PHKH"] != null)
                {
                    model.PHKH = row["PHKH"].ToString();
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
            strSql.Append("select KHBH,PMGC,PHGC,PMKH,PHKH,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
            strSql.Append(" FROM fmd100 ");
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
            strSql.Append("select count(1) FROM fmd100 ");
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
                strSql.Append("order by T.PHGC desc");
            }
            strSql.Append(")AS Row, T.*  from fmd100 T ");
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

        public DataTable GetSpread(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.khbh KHBH,b.KHMC KHMC,a.PMGC PMGC,  ");
            strSql.Append("a.PHGC PHGC,a.PMKH PMKH,a.PHKH PHKH,a.CLBHGC CLBHGC,a.CLBHKH CLBHKH from fmd100 a   ");
            strSql.Append(" left join fmd030 b on a.khbh = b.khbh  ");
               
            if (strWhere.Trim() != "")
            {
                strSql.Append("where b.KHMC = '" + strWhere + "'  ");
            }
            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }

        public DataTable Getsub3Fmd060(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.khbh KHBH,b.KHMC KHMC,a.PMGC PMGC,  ");
            strSql.Append("a.PHGC PHGC,a.PMKH PMKH,a.PHKH PHKH from fmd100 a   ");
            strSql.Append(" left join fmd030 b on a.khbh = b.khbh  ");

            if (strWhere.Trim() != "")
            {
                strSql.Append("where b.KHMC = '" + strWhere + "'  ");
            }
            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}
