using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {
        /*  public string GetConnectionString(string name)
          {
              return ConfigurationManager.ConnectionStrings[name].ConnectionString;
          }*/

        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionString)
        {
            //string connectionString = GetConnectionString(connectionStringName);
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
    }
}
