using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace ResolveResXml.DAL
{
	/// <summary>
	/// 数据访问类:res_XML
	/// </summary>
	public partial class res_XML
	{
		public res_XML()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ResolveResXml.Model.res_XML model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into res_XML(");
			strSql.Append("id,key,value,projectId)");
			strSql.Append(" values (");
			strSql.Append("@id,@key,@value,@projectId)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,8),
					new SQLiteParameter("@key", DbType.String),
					new SQLiteParameter("@value", DbType.String),
					new SQLiteParameter("@projectId", DbType.Int32,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.key;
			parameters[2].Value = model.value;
			parameters[3].Value = model.projectId;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(ResolveResXml.Model.res_XML model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update res_XML set ");
			strSql.Append("id=@id,");
			strSql.Append("key=@key,");
			strSql.Append("value=@value,");
			strSql.Append("projectId=@projectId");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,8),
					new SQLiteParameter("@key", DbType.String),
					new SQLiteParameter("@value", DbType.String),
					new SQLiteParameter("@projectId", DbType.Int32,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.key;
			parameters[2].Value = model.value;
			parameters[3].Value = model.projectId;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from res_XML ");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
			};

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
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
		public ResolveResXml.Model.res_XML GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,key,value,projectId from res_XML ");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
			};

			ResolveResXml.Model.res_XML model=new ResolveResXml.Model.res_XML();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["key"]!=null && ds.Tables[0].Rows[0]["key"].ToString()!="")
				{
					model.key=ds.Tables[0].Rows[0]["key"].ToString();
				}
				if(ds.Tables[0].Rows[0]["value"]!=null && ds.Tables[0].Rows[0]["value"].ToString()!="")
				{
					model.value=ds.Tables[0].Rows[0]["value"].ToString();
				}
				if(ds.Tables[0].Rows[0]["projectId"]!=null && ds.Tables[0].Rows[0]["projectId"].ToString()!="")
				{
					model.projectId=int.Parse(ds.Tables[0].Rows[0]["projectId"].ToString());
				}
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
			strSql.Append("select id,key,value,projectId ");
			strSql.Append(" FROM res_XML ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM res_XML ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            object obj = DbHelperSQLite.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from res_XML T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "res_XML";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

