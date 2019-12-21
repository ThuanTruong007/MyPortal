using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataManagement.Entities.Enums
{
    public enum DatabaseConnection
    {
        [Description("Application Database")]
        AppDb =0,
        [Description("Log Database")]
        LogDb = 1,
        [Description("Staging Database")]
        StagingDB = 2
    }
}
