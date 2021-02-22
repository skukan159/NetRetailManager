using DataManager.Domain.DAO.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
        Task<RegistrationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<bool> UpdateUserRoles(string userId, IEnumerable<string> userRoles);
        Task<IdentityUser> GetUserById(string userId);
        Task<List<IdentityUser>> GetUsers();
        Task<bool> DeleteUser(string userId);
        Task<List<UserRole>> GetUserRoles(string userId);
        Task<IEnumerable<string>> GetRoles();
    }
}
