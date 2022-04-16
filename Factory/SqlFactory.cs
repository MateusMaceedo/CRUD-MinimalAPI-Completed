using System.Data;
using Microsoft.Data.SqlClient;

namespace MinimalApiCrud.Factory
{
    public class SqlFactory
    {
        public IDbConnection SqlConnection()
        {
          return new SqlConnection("Server=MATEUS\\SQLEXPRESS; Database=master; User=ma; Password=20252361; Trusted_Connection=False; TrustServerCertificate=True;");
        }
    }
}
