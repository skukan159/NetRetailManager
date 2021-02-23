using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess : IDisposable
    {

        private IDbConnection _connection;
        private IDbTransaction _transaction;


        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionString)
        {
            using IDbConnection cnn = new SqlConnection(connectionString);
            var result = await cnn
                .QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            List<T> rows = result.ToList();

            return rows;
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionString)
        {
            //string connectionString = GetConnectionString(connectionStringName);
            using IDbConnection cnn = new SqlConnection(connectionString);
            await cnn.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }


        public void StartTransaction(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();

            _transaction = _connection.BeginTransaction();
        }

        public async Task SaveDataInTransaction<T>(string storedProcedure, T parameters)
        {
            await _connection
                .ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        public async Task<List<T>> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
        {
            var result = await _connection
                .QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);

            List<T> rows = result.ToList();

            return rows;
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();
        }

        public void Dispose()
        {
            CommitTransaction();
        }
    }
}
