using DataManager.Library.Internal.DataAccess;
using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "DefaultConnection");

            return output;
        }
    }
}
