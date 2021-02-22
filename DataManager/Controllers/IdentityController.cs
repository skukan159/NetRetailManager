using DataManager.Contracts;
using DataManager.Contracts.V1.DTO.Auth;
using DataManager.Domain.DAO.Auth;
using DataManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Controllers
{
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost(ApiRoutes.Identity.SetUserRole)]
        public async Task<IActionResult> SetUserRole([FromBody] SetUserRoleRequest setUserRoleRequest)
        {
            var result = await _identityService.UpdateUserRoles(setUserRoleRequest.UserId, setUserRoleRequest.Roles);

            if (result == false)
                return NotFound("Updating user role failed.");
            return Ok(true);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet(ApiRoutes.Identity.GetUserRoles)]
        public async Task<IActionResult> GetUserRoles([FromRoute] string userId)
        {
            var result = await _identityService.GetUserRoles(userId);
            if (result == null)
                return NotFound();
            return Ok(result);

        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet(ApiRoutes.Identity.GetRoles)]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _identityService.GetRoles();
            if (result == null)
                return NotFound();
            return Ok(result);

        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet(ApiRoutes.Identity.GetUsers)]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _identityService.GetUsers();
            if (result == null)
                return NotFound("Cannot find users");

            var userResponses = new List<IdentityUser>();

            foreach (var user in result)
            {
                userResponses.Add(user);
            }

            return Ok(userResponses);

        }

        [HttpGet(ApiRoutes.Identity.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute] string userId)
        {
            var user = await _identityService.GetUserById(userId);
            if (user == null)
                return NotFound("Cannot find user with this ID");

            return Ok(user);

        }


        [Authorize(Roles = Roles.Admin)]
        [HttpGet(ApiRoutes.Identity.DeleteUser)]
        public async Task<IActionResult> DeleteUser([FromRoute] string userId)
        {
            var result = await _identityService.DeleteUser(userId);

            if (result == false)
                return NotFound("Could not delete user. Check if the right user ID was inserted.");

            return Ok();

        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (authResponse.Success)
            {
                var user = await _identityService.GetUserById(authResponse.UserId);
            }

            if (!authResponse.Success)
                return BadRequest(new AuthFailedResponse { Errors = authResponse.Errors });


            return Ok();
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken
            });
        }

        [HttpPost(ApiRoutes.Identity.Refresh)]
        public async Task<IActionResult> Login([FromBody] RefreshTokenRequest request)
        {
            var authResponse = await _identityService.RefreshTokenAsync(request.Token, request.RefreshToken);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken
            });
        }

    }
}
