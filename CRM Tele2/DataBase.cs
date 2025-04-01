using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Tele2
{
    public static class DataBase
    {
        private static string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=Yes;";

        public static SqlConnection GetConnection( )
        {
            return new SqlConnection(connectionString);
        }
    }
}
