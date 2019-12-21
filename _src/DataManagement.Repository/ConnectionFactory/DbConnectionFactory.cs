using DataManagement.Entities.Enums;
using DataManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataManagement.Repository
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IDictionary<DatabaseConnection, string> _databaseConnections;

        public DbConnectionFactory(IDictionary<DatabaseConnection, string> databaseConnections)
        {
            _databaseConnections = databaseConnections;
        }

        public string GetDbConnection(DatabaseConnection databaseConnection)
        {
            if (_databaseConnections.TryGetValue(databaseConnection, out var connectionString))
            {
                return connectionString;
            }

            throw new ArgumentNullException();
        }
    }
}
