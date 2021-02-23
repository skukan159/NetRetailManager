using DataManager.Library.Internal.DataAccess;
using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public class UserData : IUserData
    {
        private readonly string connectionString;

        public UserData(string connString)
        {
            connectionString = connString;
        }

        public async Task<List<UserModel>> GetUserById(string id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = id };

            var output = await sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, connectionString);

            return output;
        }
    }
}
