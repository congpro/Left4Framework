/*
 * Dapper Extensions
 * nod by bluexray
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Dynamic;
using System.Data.SqlClient;
using System.Configuration;

using SQLinq;
using Dapper;

namespace Framework.DataAccess.ORM.Dapper
{
    public static class IDbConnectionExtensions
    {
        public static IDbConnection _connection = null;
        public static string _con = null;  

        private static void ConnectionString()
        {
            if (!string.IsNullOrEmpty(_con))
            {
                _connection = new SqlConnection(ConfigurationManager.ConnectionStrings[_con].ConnectionString);
            }
            else
            {
                _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterConnectionString"].ConnectionString);
            }
        }

        public static IEnumerable<T>  Query<T>(SQLinq<T> query,
            IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
            where T : new()
        {

            if (_connection != null && _connection.State != ConnectionState.Open)
                _connection.Open();

            var result = query.ToSQL();

            var sql = result.ToQuery();
            var parameters = new DictionaryParameterObject(result.Parameters);

            try
            {
                return SqlMapper.Query<T>(_connection, sql, parameters, transaction, buffered, commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    _connection.Close();
            }
        }

        public static  IEnumerable<dynamic> Query(this IDbConnection dbconnection, ISQLinq query,
          IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (_connection != null && _connection.State != ConnectionState.Open)
                _connection.Open();

            var result = query.ToSQL();

            var sql = result.ToQuery();
            var parameters = new DictionaryParameterObject(result.Parameters);

            try
            {
            	return SqlMapper.Query(dbconnection, sql, parameters, transaction, buffered, commandTimeout, commandType);
            }
            finally
            {
                if(buffered)
                    _connection.Close();
            }
        }
    }

    public class DictionaryParameterObject : SqlMapper.IDynamicParameters
    {
        public DictionaryParameterObject(IDictionary<string, object> dictionary)
        {
            this.Dictionary = dictionary;
        }

        public IDictionary<string, object> Dictionary { get; private set; }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            foreach (var item in this.Dictionary)
            {
                var p = command.CreateParameter();
                p.ParameterName = item.Key;
                p.Value = item.Value;
                command.Parameters.Add(p);
            }
        }
    }

}
