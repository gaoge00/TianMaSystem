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
using System.Collections.Generic;
//using Common;
using Model;
namespace BLL
{
    /// <summary>
    /// ffd050
    /// </summary>
    public partial class ffd050
    {
        private readonly DAL.ffd050 dal = new DAL.ffd050();
        public ffd050()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CKZLBH)
        {
            return dal.Exists(CKZLBH);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.ffd050 model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.ffd050 model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CKZLBH)
        {

            return dal.Delete(CKZLBH);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        //public bool DeleteList(string CKZLBHlist )
        //{
        //    return dal.DeleteList(Common.PageValidate.SafeLongFilter(CKZLBHlist,0) );
        //}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CKZLBHlist)
        {
            return dal.DeleteList(CKZLBHlist);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ffd050 GetModel(string CKZLBH)
        {

            return dal.GetModel(CKZLBH);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public Model.ffd050 GetModelByCache(string CKZLBH)
        //{

        //    string CacheKey = "ffd050Model-" + CKZLBH;
        //    object objModel = Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(CKZLBH);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Model.ffd050)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.ffd050> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.ffd050> DataTableToList(DataTable dt)
        {
            List<Model.ffd050> modelList = new List<Model.ffd050>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.ffd050 model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获得绑定CboBox的出库指令数据
        /// </summary>
        /// <returns></returns>
        public DataTable getAllCKZLBH_CBOX(string CKZLRQ,string WCQF)
        {
            return dal.getAllCKZLBH_CBOX(CKZLRQ,WCQF);
        }

        /// <summary>
        /// 获得绑定CboBox的出库指令数据
        /// </summary>
        /// <returns></returns>
        public DataTable getAllCKZLBH_CBOX()
        {
            return dal.getAllCKZLBH_CBOX();
        }

        /// <summary>
        /// 获得绑定CboBox的出库指令数据
        /// </summary>
        /// <returns></returns>
        public DataTable getCKZLBH_Info(string CKZLBH)
        {
            return dal.getCKZLBH_Info(CKZLBH);
        }

        /// <summary>
        /// 获得绑定CboBox的出库指令数据
        /// </summary>
        /// <returns></returns>
        public bool SaveWLCK(Model.ffd050 modelFFD050, List<string> listStrX, List<string> listStrDD, List<string> listStrXD)
        {
            return dal.SaveWLCK(modelFFD050, listStrX, listStrDD, listStrXD);
        }


        /// <summary>
        /// 根据本次应出的数量，推算出应出的箱LOT，大袋LOT，小袋LOT
        /// </summary>
        /// <param name="CKZLBH">出库指令编号</param>
        /// <returns></returns>
        public DataTable getLLCK(string CKZLBH,int Xnum, int DDnum, int XDnum)
        {
            return dal.getLLCK(CKZLBH,Xnum, DDnum, XDnum);
        }

        /// <summary>
        /// 得到最大的追番+1
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetMaxZF(Model.ffd050 model)
        {
            return dal.GetMaxZF(model);

        }
        /// <summary>
        /// 删除当次出库的数据
        /// </summary>
        /// <param name="CKZLBH"></param>
        /// <returns></returns>
        public bool deleteWLCK(string CKZLBH)
        {
            return dal.deleteWLCK(CKZLBH);
        }

        /// <summary>
        /// 获得出库指令明细
        /// </summary>
        public DataSet GetCKZLMX(string strWhere)
        {
            return dal.GetCKZLMX(strWhere);
        }

        public DataSet GetCKZLMXEXCEL(string strWhere)
        {
            return dal.GetCKZLMXEXCEL(strWhere);
        }

        public DataSet GetdtForCry(string strWhere)
        {
            return dal.GetdtForCry(strWhere);
        }
        /// <summary>
        /// 获得成品出库明细
        /// </summary>
        public DataSet GetCPCKMX(string strWhere)
        {
            return dal.GetCPCKMX(strWhere);
        }
        #endregion  ExtensionMethod


        /// <summary>
        /// PC25 检索01
        /// </summary>
        public DataTable GetPc25Js01(string strStartRq, string strEndRq, string strKhbh)
        {
            return dal.GetPc25Js01(strStartRq, strEndRq, strKhbh);
        }
    }
}

