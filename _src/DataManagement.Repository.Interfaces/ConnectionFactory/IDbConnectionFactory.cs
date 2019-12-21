using DataManagement.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataManagement.Repository.Interfaces
{

    public interface IDbConnectionFactory
    {
        string GetDbConnection(DatabaseConnection databaseConnection);
    }
}
