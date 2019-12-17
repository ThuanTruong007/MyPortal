using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DataManagement.Repository
{
    public class BaseRepository : IDisposable
    {
        private readonly string _connectionString; 
        public BaseRepository()
        {
            //.ConfigureManager.
            _connectionString = "Server=X1Analytics;Database=AppDb;Integrated Security=true";
        }
        public BaseRepository(string connectionString)
        {
            if(string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException(connectionString);
            }
            _connectionString = connectionString;
        }

        protected SqlConnection NewSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();  
        }
    }
}
