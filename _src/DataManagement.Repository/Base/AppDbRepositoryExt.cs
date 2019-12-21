using DataManagement.Entities.Enums;
using DataManagement.Repository;
using DataManagement.Repository.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataManagement.Repository
{
    public class AppDbRepositoryBase<T> : RepositoryBase<T>, IAppDbRepository<T> where T : class
    {
        public AppDbRepositoryBase(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory.GetDbConnection(DatabaseConnection.AppDb)) { }
    }
}
