/**  版本信息模板在安装目录下，可自行修改。
* fmd010.cs
*
* 功 能： N/A
* 类 名： fmd010
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
    /// 数据访问类:fmd010
    /// </summary>
    public partial class fmd010
    {
        public fmd010()
        { }
        #region  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SYBH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from fmd010");
            strSql.Append(" where SYBH='" + SYBH + "' ");
            return DbHelperMySql.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string AddSQL(Model.fmd010 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.SYBH != null)
            {
                strSql1.Append("SYBH,");
                strSql2.Append("'" + model.SYBH + "',");
            }
            if (model.SYMC != null)
            {
                strSql1.Append("SYMC,");
                strSql2.Append("'" + model.SYMC + "',");
            }
            if (model.BMBH != null)
            {
                strSql1.Append("BMBH,");
                strSql2.Append("'" + model.BMBH + "',");
            }
            if (model.ZWBH != null)
            {
                strSql1.Append("ZWBH,");
                strSql2.Append("'" + model.ZWBH + "',");
            }
            if (model.XB != null)
            {
                strSql1.Append("XB,");
                strSql2.Append("'" + model.XB + "',");
            }
            if (model.SR != null)
            {
                strSql1.Append("SR,");
                strSql2.Append("'" + model.SR + "',");
            }
            if (model.ZZ != null)
            {
                strSql1.Append("ZZ,");
                strSql2.Append("'" + model.ZZ + "',");
            }
            if (model.SFZ != null)
            {
                strSql1.Append("SFZ,");
                strSql2.Append("'" + model.SFZ + "',");
            }
            if (model.SJH != null)
            {
                strSql1.Append("SJH,");
                strSql2.Append("'" + model.SJH + "',");
            }
            if (model.EMAIL != null)
            {
                strSql1.Append("EMAIL,");
                strSql2.Append("'" + model.EMAIL + "',");
            }
            if (model.ZT != null)
            {
                strSql1.Append("ZT,");
                strSql2.Append("'" + model.ZT + "',");
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




            if (model.PORTID != null)
            {
                strSql1.Append("PORTID,");
                strSql2.Append("'" + model.PORTID + "',");
            }
            if (model.PRINTERID != null)
            {
                strSql1.Append("PRINTERID,");
                strSql2.Append("'" + model.PRINTERID + "',");
            }
            
          

            strSql.Append("insert into fmd010(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return  strSql.ToString();
          
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string UpdateSQL(Model.fmd010 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update fmd010 set ");
            if (model.SYMC != null)
            {
                strSql.Append("SYMC='" + model.SYMC + "',");
            }
            if (model.BMBH != null)
            {
                strSql.Append("BMBH='" + model.BMBH + "',");
            }
            if (model.ZWBH != null)
            {
                strSql.Append("ZWBH='" + model.ZWBH + "',");
            }
            else
            {
                strSql.Append("ZWBH= null ,");
            }
            if (model.XB != null)
            {
                strSql.Append("XB='" + model.XB + "',");
            }
            else
            {
                strSql.Append("XB= null ,");
            }
            if (model.SR != null)
            {
                strSql.Append("SR='" + model.SR + "',");
            }
            else
            {
                strSql.Append("SR= null ,");
            }
            if (model.ZZ != null)
            {
                strSql.Append("ZZ='" + model.ZZ + "',");
            }
            else
            {
                strSql.Append("ZZ= null ,");
            }
            if (model.SFZ != null)
            {
                strSql.Append("SFZ='" + model.SFZ + "',");
            }
            else
            {
                strSql.Append("SFZ= null ,");
            }
            if (model.SJH != null)
            {
                strSql.Append("SJH='" + model.SJH + "',");
            }
            else
            {
                strSql.Append("SJH= null ,");
            }
            if (model.EMAIL != null)
            {
                strSql.Append("EMAIL='" + model.EMAIL + "',");
            }
            else
            {
                strSql.Append("EMAIL= null ,");
            }
            if (model.ZT != null)
            {
                strSql.Append("ZT='" + model.ZT + "',");
            }
            else
            {
                strSql.Append("ZT= null ,");
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

            if (model.PORTID != null)
            {
                strSql.Append("PORTID='" + model.PORTID + "',");
            }
            else
            {
                strSql.Append("PORTID= null ,");
            }

            if (model.PRINTERID != null)
            {
                strSql.Append("PRINTERID='" + model.PRINTERID + "',");
            }
            else
            {
                strSql.Append("PRINTERID= null ,");
            }

            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where SYBH='" + model.SYBH + "' ");
            return    strSql.ToString();
           
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SYBH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fmd010 ");
            strSql.Append(" where SYBH='" + SYBH + "' ");
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
        public bool DeleteList(string SYBHlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fmd010 ");
            strSql.Append(" where SYBH in (" + SYBHlist + ")  ");
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
        public Model.fmd010 GetModel(string SYBH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" SYBH,SYMC,BMBH,ZWBH,XB,SR,ZZ,SFZ,SJH,EMAIL,ZT,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
            strSql.Append(" from fmd010 ");
            strSql.Append(" where SYBH='" + SYBH + "' ");
            Model.fmd010 model = new Model.fmd010();
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
        public Model.fmd010 DataRowToModel(DataRow row)
        {
            Model.fmd010 model = new Model.fmd010();
            if (row != null)
            {
                if (row["SYBH"] != null)
                {
                    model.SYBH = row["SYBH"].ToString();
                }
                if (row["SYMC"] != null)
                {
                    model.SYMC = row["SYMC"].ToString();
                }
                if (row["BMBH"] != null)
                {
                    model.BMBH = row["BMBH"].ToString();
                }
                if (row["ZWBH"] != null)
                {
                    model.ZWBH = row["ZWBH"].ToString();
                }
                if (row["XB"] != null)
                {
                    model.XB = row["XB"].ToString();
                }
                if (row["SR"] != null)
                {
                    model.SR = row["SR"].ToString();
                }
                if (row["ZZ"] != null)
                {
                    model.ZZ = row["ZZ"].ToString();
                }
                if (row["SFZ"] != null)
                {
                    model.SFZ = row["SFZ"].ToString();
                }
                if (row["SJH"] != null)
                {
                    model.SJH = row["SJH"].ToString();
                }
                if (row["EMAIL"] != null)
                {
                    model.EMAIL = row["EMAIL"].ToString();
                }
                if (row["ZT"] != null)
                {
                    model.ZT = row["ZT"].ToString();
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
            strSql.Append("select SYBH,SYMC,BMBH,ZWBH,XB,SR,ZZ,SFZ,SJH,EMAIL,ZT,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
            strSql.Append(" FROM fmd010 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySql.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到打印机信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable GetPrinterInfo(string uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.SYBH,B.ZSMC as PrinterID ,c.ZSMC as PortID from fmd010 a ");
            strSql.Append(" left join fmd000 b on (b.glbh='12' and a.PrinterID = b.MCKEY) ");
            strSql.Append(" left join fmd000 c on (c.glbh='13' and a.PortID = c.MCKEY) ");
            strSql.Append(" where a.SYBH='" + uid + "' ");

            return DbHelperMySql.Query(strSql.ToString()).Tables[0];

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListPc26(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select '' SYMC union  select SYMC ");
            strSql.Append(" FROM fmd010 ");
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
            strSql.Append("select count(1) FROM fmd010 ");
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
                strSql.Append("order by T.SYBH desc");
            }
            strSql.Append(")AS Row, T.*  from fmd010 T ");
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
        public DataTable GetNameForList()//检索所有社员名
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("select SYBH,SYMC XM from fmd010 ");
            return DbHelperMySql.Query(StrSQL.ToString()).Tables[0];
        }


        public DataSet GetDaTaForPC05Spread(string strSYNAME, string strSYBH)
        {
            StringBuilder StrSQL = new StringBuilder();


            StrSQL.Append("   SELECT sybh,symc,bmbh, b.zsmc BM,zwbh, c.zsmc zw ,case  when xb='1' then '男' when '2' then '女'  END xb  ,sr ,zz ,sfz ,sjh ,email ,ZT,d.zsmc IP,e.zsmc DK from fmd010 a ");
            StrSQL.Append(" LEFT JOIN ( SELECT MCKEY,ZSMC FROM fmd000 WHERE GLBH='01') b ON (a.BMBH= b.MCKEY) ");
            StrSQL.Append(" LEFT JOIN ( SELECT MCKEY,ZSMC FROM fmd000 WHERE GLBH='02') c ON (a.ZWBH= c.MCKEY) ");
            StrSQL.Append(" LEFT JOIN ( SELECT MCKEY,ZSMC FROM fmd000 WHERE GLBH='12') d ON (a.PRINTERID= d.MCKEY) ");
            StrSQL.Append(" LEFT JOIN ( SELECT MCKEY,ZSMC FROM fmd000 WHERE GLBH='13') e ON (a.PORTID= e.MCKEY)  WHERE 1=1 ");
          

            if (!string.IsNullOrEmpty(strSYNAME))
            {//社员名称
                StrSQL.Append(" AND a.symc LIKE '" + strSYNAME + "%" + "' ");
            }
            if (!string.IsNullOrEmpty(strSYBH))
            {//社员编号
                StrSQL.Append(" AND a.SYBH = '" + strSYBH.ToString().Trim() + "' ");
            }
            StrSQL.Append("ORDER BY A.BMBH,CONVERT(A.SYBH,SIGNED)");
            return DbHelperMySql.Query(StrSQL.ToString());
        }



        public DataSet GetDaTaForWinSubKey_Value(string TB_NAME ,string strKEY, string strVALUE)
        {
            StringBuilder StrSQL = new StringBuilder();


            StrSQL.Append("  SELECT KHBH as strKEY,KHMC as strVALUE from " + TB_NAME + " a  ");
            StrSQL.Append("   WHERE 1=1 ");


            if (!string.IsNullOrEmpty(strVALUE))
            {//社员名称
                StrSQL.Append(" AND a.KHMC LIKE '" + strVALUE + "%" + "' ");
            }
            if (!string.IsNullOrEmpty(strKEY))
            {//社员编号
                StrSQL.Append(" AND a.KHBH = '" + strKEY.ToString().Trim() + "' ");
            }
            StrSQL.Append("ORDER BY A.KHBH");
            return DbHelperMySql.Query(StrSQL.ToString());
        }


        public string GetData_Value(string TB_NAME, string strKEY, string strVALUE)
        {
            StringBuilder StrSQL = new StringBuilder();


            StrSQL.Append("  SELECT KHBH as strKEY,KHMC as strVALUE from " + TB_NAME + " a  ");
            StrSQL.Append("   WHERE 1=1 ");


            if (!string.IsNullOrEmpty(strVALUE))
            {//社员名称
                StrSQL.Append(" AND a.KHMC LIKE '" + strVALUE + "%" + "' ");
            }
            if (!string.IsNullOrEmpty(strKEY))
            {//社员编号
                StrSQL.Append(" AND a.KHBH = '" + strKEY.ToString().Trim() + "' ");
            }
            StrSQL.Append("ORDER BY A.KHBH");
            DataTable dt;
            dt=DbHelperMySql.Query(StrSQL.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][1].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        public string GetData_SYNAME( string strKEY, string strVALUE)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("select SYBH,SYMC XM from fmd010 a  WHERE 1=1  ");

         
            if (!string.IsNullOrEmpty(strKEY))
            {//社员编号
                StrSQL.Append(" AND a.SYBH = '" + strKEY.ToString().Trim() + "' ");
            }

            DataTable dt;
            dt = DbHelperMySql.Query(StrSQL.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][1].ToString();
            }
            else
            {
                return string.Empty;
            }
        }


        public string GetDelete(string SYBH)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("Update FMD010 Set ZT= '0'");
            StrSQL.Append("where SYBH = '" + SYBH + "' ");
            return StrSQL.ToString();
        }
        public DataSet GetSYBH(string SYBH, string SCQF)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("select * from FMD010 ");
            StrSQL.Append("where sybh = '" + SYBH + "' ");
            StrSQL.Append(" and ZT = " + SCQF + " ");
            return DbHelperMySql.Query(StrSQL.ToString());
        }
        //public bool Exists(string SYBH)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(1) from FMD010");
        //    strSql.Append(" where SYBH='" + SYBH + "' ");
        //    return DbHelperMySql.Exists(strSql.ToString());
        //}

        /// <summary>
        /// WinFmd310社员录入画面删除社员数据恢复
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string DeleteSybhRecover(string SYBH)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append("Update FMD010 Set ZT= '1'");
            StrSQL.Append("where SYBH = '" + SYBH + "' ");
            return StrSQL.ToString();
        }

        /// <summary>
        /// 根据社员编号获取社员名称
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string getSYMCBySYBH(string SYBH)
        {
            StringBuilder StrSQL = new StringBuilder();
            StrSQL.Append(" select SYMC from FMD010 ");
            StrSQL.Append(" where SYBH = '" + SYBH + "' ");
            return StrSQL.ToString();
        }


        #endregion  MethodEx
    }
}

