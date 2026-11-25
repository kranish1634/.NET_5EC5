
using System.Configuration;
using System.Data.SqlClient;

namespace PlacementDashboard.Data
{
    public static class DatabaseConnection
    {
        public static SqlConnection GetConnection()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["PlacementDB"]
                .ConnectionString;

            return new SqlConnection(connectionString);
        }
    }
}
