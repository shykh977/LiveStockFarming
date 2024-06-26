using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Data.SqlClient;
using Dapper;

namespace PwDbAssistant.DbConnect
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        IConnection _connection;
        public GenericRepository(IConnection connection)
        {
            _connection = connection;
        }
      
        public TEntity Delete(int Id)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage]
        public TEntity GetById(int Id)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<TEntity> Search(object parameters, string query)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                conn.Open();
                return conn.Query<TEntity>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }

        public IEnumerable<Model> Search<Model>(object parameters, string query)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                conn.Open();
                return conn.Query<Model>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }

      

        public IEnumerable<Model> ExecuteQuery<Model>(object parameters, string query)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                conn.Open();
                return conn.Query<Model>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }
        
        
        public IEnumerable<Model> ExecuteSearch<Model>(IDictionary<string,string> valuePairs, string query)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                conn.Open();
                return conn.Query<Model>(query, valuePairs, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }

        public Model CreateSP<Model>(Model model, string storedProcName)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                conn.Open();
                return conn.Query<Model>(storedProcName, model, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<Model> Search<Model>(object parameters, string sql, string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
