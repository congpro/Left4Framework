using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ResolveResXml.Model;
namespace ResolveResXml.BLL
{
	/// <summary>
	/// res_XML
	/// </summary>
	public partial class res_XML
	{
		private readonly ResolveResXml.DAL.res_XML dal=new ResolveResXml.DAL.res_XML();
		public res_XML()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ResolveResXml.Model.res_XML model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ResolveResXml.Model.res_XML model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ResolveResXml.Model.res_XML GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ResolveResXml.Model.res_XML GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "res_XMLModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ResolveResXml.Model.res_XML)objModel;
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
		public List<ResolveResXml.Model.res_XML> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ResolveResXml.Model.res_XML> DataTableToList(DataTable dt)
		{
			List<ResolveResXml.Model.res_XML> modelList = new List<ResolveResXml.Model.res_XML>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ResolveResXml.Model.res_XML model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ResolveResXml.Model.res_XML();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["key"]!=null && dt.Rows[n]["key"].ToString()!="")
					{
					model.key=dt.Rows[n]["key"].ToString();
					}
					if(dt.Rows[n]["value"]!=null && dt.Rows[n]["value"].ToString()!="")
					{
					model.value=dt.Rows[n]["value"].ToString();
					}
					if(dt.Rows[n]["projectId"]!=null && dt.Rows[n]["projectId"].ToString()!="")
					{
						model.projectId=int.Parse(dt.Rows[n]["projectId"].ToString());
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

