using System;
using System.Data;
using Dapper;
using UserRegistrationSample.Models;
using UserRegistrationSample.Providers;

namespace UserRegistrationSample.Repositories
{
    public class UserRepository : IDisposable
    {
        private IDbConnection _db;
        private DbConnectionProvider _dbProvider;

        public UserRepository()
        {
            //fetch database credentials from config and connect
            //_dbProvider = new DbConnectionProvider(dbServer, username, password);
        }

        public IDbConnection Db
        {
            get { return _db ?? (_db = _dbProvider.GetDataStoreConnection()); }
            set
            {
                _db = value;
            }
        }
        public void RegisterUser(RegisterBindingModel model)
        {
            var sprocParameters = new DynamicParameters();
            var email = model.Email;
            var password = model.Password;//TODO: Hash password before saving

            sprocParameters.Add("@Email", model.Email);
            sprocParameters.Add("@password", password);

            Db.Execute("RegisterUser", sprocParameters, commandType: CommandType.StoredProcedure);

        }

        public void Dispose()
        {
            if (_dbProvider != null)
            {
                _dbProvider.Dispose();
            }
        }
    }
}