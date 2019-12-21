using Dapper;
using DataManagement.Entities;
using DataManagement.Entities.Enums;
using DataManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static System.Data.CommandType;

namespace DataManagement.Repository.Repository
{
    public class AppConfigRepository : AppDbRepositoryExt<AppConfig>, IAppConfigRepository
    {
        public AppConfigRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory) { }     
    }
}
