using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Saraha.Core.Common;

namespace Saraha.Infra.Common
{
    public class Dbcontext: IDbcontext
    {
        private DbConnection _connection;
        private readonly IConfiguration _configuration;
        public Dbcontext(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public DbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new OracleConnection(_configuration["ConnectionStrings:DBConnectionString"]);
                    _connection.Open();
                }
                else if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }

        }
    }
}
