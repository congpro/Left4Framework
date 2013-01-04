/***********************************************************************
 *  Copyright (C) 2011 Framework Corporation
 *  All rights reserved.
 * 
 *  Author:  Peter.Li
 *  Date:    2012-06-04 09:43:57
 *  Purpose: 
 * 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using MySql.Data.MySqlClient;

namespace Framework.DataAccess.MYSQL
{
     class MYSQLDataAccess : DataAccessor,IDataBaseExecutor
    {
        private SqlConnection con = null;

        MYSQLDataAccess(string SqlConnection)
        {
            SqlConnection con = new SqlConnection(SqlConnection);
        }

        MYSQLDataAccess()
        {
            string sqlcon = ConfigurationManager.AppSettings["MYSQL"];
            con = new SqlConnection(sqlcon);
        }

        public DataTable ExecuteDataTable(string commandText, CommandType commandType)
        {
            string providerName = "MySql.Data.MySqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            //GenericDatabase gen =  new GenericDatabase(con,factory);
            con.Open();
            SqlCommand cmd = new SqlCommand(commandText, con);
            
            SqlDataAdapter adapter = new SqlDataAdapter(commandText, con);
            
            return null;
        }

        public DataTable ExecuteDataTable(string commandText, params IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteDataTable(string commandText, CommandType commandType, params IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        public DataSet ExecuteDataSet(string commandText, CommandType commandType)
        {
            throw new NotImplementedException();
        }

        public DataSet ExecuteDataSet(string commandText, params IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        public DataSet ExecuteDataSet(string commandText, CommandType commandType, params IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        public T ExecuteScalar<T>(string commandText, CommandType commandType)
        {
            throw new NotImplementedException();
        }

        public T ExecuteScalar<T>(string commandText, params IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        public T ExecuteScalar<T>(string commandText, CommandType commandType, params IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string commandText, params IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType, params IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Specialized.NameValueCollection ExecuteEntity(string commandText, CommandType commandType)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Specialized.NameValueCollection ExecuteEntity(string commandText, params IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Specialized.NameValueCollection ExecuteEntity(string commandText, CommandType commandType, params IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            con = null;
        }

        public override string DBMS
        {
            get { return "MySql"; }
        }
    }
}
