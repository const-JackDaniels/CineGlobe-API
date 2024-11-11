using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CineGlobeAPI.Access
{
    public class Database
    {
        private readonly IConfiguration _configuration;
        private SqlConnection _sqlConn;

        public Database()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
            _sqlConn = new SqlConnection(_configuration.GetConnectionString("mymoviedb"));
        }

        public enum DatabaseType
        {
            SQL
        }

        public SqlTransaction CreateTransaction()
        {
            _sqlConn.Open();
            return _sqlConn.BeginTransaction();
        }

        public DataTable RunSQLReturnTableData(string sql, DatabaseType databaseType = DatabaseType.SQL)
        {
            var dataTable = new DataTable();

            var sqlConn = _sqlConn;

            try
            {
                using (sqlConn)
                {
                    if (sqlConn.State != ConnectionState.Open)
                    {
                        sqlConn.Open();
                    }
                    var sqlAdapter = new SqlDataAdapter(sql, sqlConn);
                    var dataSet = new DataSet();
                    sqlAdapter.Fill(dataSet);
                    if (dataSet.Tables.Count > 0 )
                    {
                        dataTable = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (sqlConn.State != ConnectionState.Closed)
                {
                    sqlConn.Close();
                }
            }

            return dataTable;
        }  
    }
}
