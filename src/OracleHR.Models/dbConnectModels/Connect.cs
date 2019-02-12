using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleHR.Models.dbConnectModels
{
    public class Connect
    {
        public DbDataReader reader { get; set; }
        public OracleConnection connection { get; set; }
    }
}
