using DataManager.Library.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DataManager.Controllers
{
    [Authorize]
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("/api/[controller]/getuser")]
        public ActionResult<List<UserData>> GetCurrentUser()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            UserData data = new UserData();
            return Ok(data.GetUserById(userId));
        }


    }
}
