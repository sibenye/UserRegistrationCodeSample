using System;
using System.Data;
using System.Data.SqlClient;

namespace UserRegistrationSample.Providers
{
    public class DbConnectionProvider : IDisposable
    {
        private IDbConnection _db; 
        private readonly string _server;
        private readonly string _dbUsername;
        private readonly string _dbPassword;


        public DbConnectionProvider(string server, string dbUsername, string dbPassword)
        {
            _server = server;
            _dbUsername = dbUsername;
            _dbPassword = dbPassword;
        }

        public IDbConnection GetDataStoreConnection()
        {
            if (_db != null) return _db;
            _db = GetSqlConnection("Data Source=" + _server + ";Initial Catalog=UserDatabase;User=" + _dbUsername + ";Password=" + _dbPassword);
            _db.Open();

            return _db;
        }

        private static SqlConnection GetSqlConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            if (_db == null)
            {
                return;
            }
            _db.Close();
            _db.Dispose();
            _db = null;
        }
    }
}