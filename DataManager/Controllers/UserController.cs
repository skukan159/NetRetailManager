using DataManager.Contracts;
using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DataManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserData _userData;

        public UserController(IUserData userData)
        {
            _userData = userData;
        }

        [HttpPost(ApiRoutes.User.GetCurrent)]
        public async Task<ActionResult<UserModel>> GetCurrentUser()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = await _userData.GetUserById(userId);
            return Ok(currentUser[0]);
        }
        [HttpDelete(ApiRoutes.User.Delete)]
        [Authorize]
        public async Task<ActionResult> DeleteUser([FromRoute] string id)
        {
            await _userData.DeleteUserById(id);
            return Ok();
        }

    }
}
