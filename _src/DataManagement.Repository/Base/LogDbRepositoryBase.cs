﻿using DataManagement.Entities.Enums;
using DataManagement.Repository;
using DataManagement.Repository.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataManagement.Repository
{
    public class LogDbRepositoryBase<T> : RepositoryBase<T>, ILogDbRepository<T> where T : class
    {
        public LogDbRepositoryBase(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory.GetDbConnection(DatabaseConnection.LogDb)) { }
    }
}

