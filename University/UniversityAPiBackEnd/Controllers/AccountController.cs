using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAPiBackEnd.DataAccess;
using UniversityAPiBackEnd.Helpers;
using UniversityAPiBackEnd.Models.DataModels;
using UniversityAPiBackEnd.Models.JwtToken;

namespace UniversityAPiBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDbContext _context;
        private readonly JwtSettings _jwtSettings;

        public AccountController(UniversityDbContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins)
        {
            try
            {
                var Token = new UserTokens();

                //Search a user in context with LINQ
                var searchUser = (from user in _context.Users
                                  where user.Name == userLogins.UserName && user.Password == userLogins.Password
                                  select user).FirstOrDefault();



                if (searchUser != null)
                {
                    Token = JwtHelpers.GenerateTokenKey(new UserTokens()
                    {
                        EmailId = searchUser.Email,
                        UserName = searchUser.Name,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid()
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Password");
                }

                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public IActionResult GetUserList()
        {
            //Search users with LINQ
            var users = (from user in _context.Users
                         select user);
            return Ok(users);
        }

    }
}
