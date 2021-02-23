using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public interface IUserData
    {
        Task<List<UserModel>> GetUserById(string id);
        Task DeleteUserById(string id);
    }
}
