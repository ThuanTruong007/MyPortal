using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataManagement.Repository.Interfaces;
using DataManagement.Entities.Enums;
using Dapper;
using System.Linq;

namespace DataManagement.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private const string KEY_COLUMN_ATTRIBUTE_NAME = "KeyAttribute";
        private const int MAX_ROW_RETURN_GETLIST = 5;
        private readonly string _connectionString;
        public RepositoryBase(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException(connectionString);
            }

            _connectionString = connectionString;
        }

        public void Insert(T entity)
        {
            using (var con = NewSqlConnection()) 
            {
                var key = con.Insert(entity);
                var keyProp = Common.Utils.GetEntityProperty<T>(KEY_COLUMN_ATTRIBUTE_NAME);
                keyProp?.SetValue(entity, key);
            }
        }

        public void Delete(T entity)
        {
            using (var con = NewSqlConnection())
            {
                con.Delete(entity);
            }
        }
        public IEnumerable<T> Get()
        {
            using (var con = NewSqlConnection())
            {
                var keyProp = Common.Utils.GetEntityProperty<T>(KEY_COLUMN_ATTRIBUTE_NAME);
                return con.GetList<T>($"where {keyProp?.Name} = @maxRow",new {maxRow=MAX_ROW_RETURN_GETLIST});
            }
        }

        public T Get(int id)
        {
            using (var con = NewSqlConnection())
            {
                return con.Get<T>(id);
            }
        }

        public void Update(T entity)
        {
            using (var con = NewSqlConnection())
            {
                con.Update(entity);
            }
        }

        protected SqlConnection NewSqlConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection?.Open();
            return connection;
        }
    }
}
