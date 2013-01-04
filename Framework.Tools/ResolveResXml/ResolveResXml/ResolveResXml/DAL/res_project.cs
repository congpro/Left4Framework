using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
using System.Collections;
namespace ResolveResXml.DAL
{
	/// <summary>
	/// 数据访问类:res_project
	/// </summary>
	public partial class res_project
	{
		public res_project()
		{}
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQLite.GetMaxID("id", "res_project");
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from res_project");
			strSql.Append(" where id=@id ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,8)			};
			parameters[0].Value = id;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据,及其子表数据
		/// </summary>
		public bool Add(ResolveResXml.Model.res_project model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into res_project(");
			strSql.Append("id,project_Name,project_CountryCode)");
			strSql.Append(" values (");
			strSql.Append("@id,@project_Name,@project_CountryCode)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,8),
					new SQLiteParameter("@project_Name", DbType.String),
					new SQLiteParameter("@project_CountryCode", DbType.String)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.project_Name;
			parameters[2].Value = model.project_CountryCode;

            List<CommandInfo> sqllist = new List<CommandInfo>();
			CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
			sqllist.Add(cmd);
			StringBuilder strSql2;
			foreach (ResolveResXml.Model.res_XML models in model.res_XMLs)
			{
				strSql2=new StringBuilder();
				strSql2.Append("insert into res_XML(");
				strSql2.Append("id,key,value,projectId)");
				strSql2.Append(" values (");
				strSql2.Append("@id,@key,@value,@projectId)");
				SQLiteParameter[] parameters2 = {
						new SQLiteParameter("@id", DbType.Int32,8),
						new SQLiteParameter("@key", DbType.String),
						new SQLiteParameter("@value", DbType.String),
						new SQLiteParameter("@projectId", DbType.Int32,4)};
				parameters2[0].Value = models.id;
				parameters2[1].Value = models.key;
				parameters2[2].Value = models.value;
				parameters2[3].Value = models.projectId;

				cmd = new CommandInfo(strSql2.ToString(), parameters2);
				sqllist.Add(cmd);
			}
			int result= DbHelperSQLite.ExecuteSqlTran(sqllist);
            if (result > 0)
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
		public bool Update(ResolveResXml.Model.res_project model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update res_project set ");
			strSql.Append("project_Name=@project_Name,");
			strSql.Append("project_CountryCode=@project_CountryCode");
			strSql.Append(" where id=@id ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,8),
					new SQLiteParameter("@project_Name", DbType.String),
					new SQLiteParameter("@project_CountryCode", DbType.String)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.project_Name;
			parameters[2].Value = model.project_CountryCode;

			int rowsAffected=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据，及子表所有相关数据
		/// </summary>
		public bool Delete(int id)
		{
            List<CommandInfo> sqllist = new List<CommandInfo>();
			StringBuilder strSql2=new StringBuilder();
			strSql2.Append("delete res_XML ");
			strSql2.Append(" where projectId=@projectId ");
			SQLiteParameter[] parameters2 = {
					new SQLiteParameter("@projectId", DbType.Int32,4)};
			parameters2[0].Value = id;

			CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2);
			sqllist.Add(cmd);
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete res_project ");
			strSql.Append(" where id=@id ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,8)			};
			parameters[0].Value = id;

			cmd = new CommandInfo(strSql.ToString(), parameters);
			sqllist.Add(cmd);
			int rowsAffected=DbHelperSQLite.ExecuteSqlTran(sqllist);
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
		public bool DeleteList(string idlist )
		{
            List<CommandInfo> sqllist = new List<CommandInfo>();
			StringBuilder strSql2=new StringBuilder();
			strSql2.Append("delete from res_XML ");
			strSql2.Append(" where projectId in ("+idlist + ")  ");
            CommandInfo cmd2 = new CommandInfo(strSql2.ToString(),null);
            sqllist.Add(cmd2);
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from res_project ");
			strSql.Append(" where id in ("+idlist + ")  ");
            CommandInfo cmd = new CommandInfo(strSql.ToString(), null);
            sqllist.Add(cmd);
			int rowsAffected=DbHelperSQLite.ExecuteSqlTran(sqllist);
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
		public ResolveResXml.Model.res_project GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,project_Name,project_CountryCode from res_project ");
			strSql.Append(" where id=@id ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,8)			};
			parameters[0].Value = id;

			ResolveResXml.Model.res_project model=new ResolveResXml.Model.res_project();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				#region  父表信息
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["project_Name"]!=null && ds.Tables[0].Rows[0]["project_Name"].ToString()!="")
				{
					model.project_Name=ds.Tables[0].Rows[0]["project_Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["project_CountryCode"]!=null && ds.Tables[0].Rows[0]["project_CountryCode"].ToString()!="")
				{
					model.project_CountryCode=ds.Tables[0].Rows[0]["project_CountryCode"].ToString();
				}
				#endregion  父表信息end

				#region  子表信息
				StringBuilder strSql2=new StringBuilder();
				strSql2.Append("select id,key,value,projectId from res_XML ");
				strSql2.Append(" where projectId=@projectId ");
			SQLiteParameter[] parameters2 = {
					new SQLiteParameter("@id", DbType.Int32,4)};
			parameters2[0].Value = id;

				DataSet ds2=DbHelperSQLite.Query(strSql2.ToString(),parameters2);
				if(ds2.Tables[0].Rows.Count>0)
				{
					#region  子表字段信息
					int i = ds2.Tables[0].Rows.Count;
					List<ResolveResXml.Model.res_XML> models = new List<ResolveResXml.Model.res_XML>();
					ResolveResXml.Model.res_XML modelt;
					for (int n = 0; n < i; n++)
					{
						modelt = new ResolveResXml.Model.res_XML();
						if(ds2.Tables[0].Rows[n]["id"]!=null && ds2.Tables[0].Rows[n]["id"].ToString()!="")
						{
							modelt.id=int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
						}
						if(ds2.Tables[0].Rows[n]["key"]!=null && ds2.Tables[0].Rows[n]["key"].ToString()!="")
						{
							modelt.key=ds2.Tables[0].Rows[n]["key"].ToString();
						}
						if(ds2.Tables[0].Rows[n]["value"]!=null && ds2.Tables[0].Rows[n]["value"].ToString()!="")
						{
							modelt.value=ds2.Tables[0].Rows[n]["value"].ToString();
						}
						if(ds2.Tables[0].Rows[n]["projectId"]!=null && ds2.Tables[0].Rows[n]["projectId"].ToString()!="")
						{
							modelt.projectId=int.Parse(ds2.Tables[0].Rows[n]["projectId"].ToString());
						}
						models.Add(modelt);
					}
					model.res_XMLs = models;
					#endregion  子表字段信息end
				}
				#endregion  子表信息end

				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,project_Name,project_CountryCode ");
			strSql.Append(" FROM res_project ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}


		#endregion  Method
	}
}

