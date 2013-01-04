using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ResolveResXml.Model;
namespace ResolveResXml.BLL
{
    /// <summary>
    /// res_project
    /// </summary>
    public partial class res_project
    {
        private readonly ResolveResXml.DAL.res_project dal = new ResolveResXml.DAL.res_project();
        public res_project()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ResolveResXml.Model.res_project model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ResolveResXml.Model.res_project model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ResolveResXml.Model.res_project GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ResolveResXml.Model.res_project GetModelByCache(int id)
        {

            string CacheKey = "res_projectModel-" + id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ResolveResXml.Model.res_project)objModel;
        }

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
        public List<ResolveResXml.Model.res_project> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ResolveResXml.Model.res_project> DataTableToList(DataTable dt)
        {
            List<ResolveResXml.Model.res_project> modelList = new List<ResolveResXml.Model.res_project>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ResolveResXml.Model.res_project model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ResolveResXml.Model.res_project();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["project_Name"] != null && dt.Rows[n]["project_Name"].ToString() != "")
                    {
                        model.project_Name = dt.Rows[n]["project_Name"].ToString();
                    }
                    if (dt.Rows[n]["project_CountryCode"] != null && dt.Rows[n]["project_CountryCode"].ToString() != "")
                    {
                        model.project_CountryCode = dt.Rows[n]["project_CountryCode"].ToString();
                    }
                    modelList.Add(model);
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

        #endregion  Method
    }
}

